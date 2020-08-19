ALTER PROCEDURE MultiTask_BotLoader
	@IO int,
	@BotID int = NULL,
	@TaskID int = NULL,
	@StartTime datetime = NULL,
	@EndTime datetime = NULL,
	@ComputerProcessID int = NULL,
	@Debug bit = 0
AS
/*
==============================================================
-- Net Bots SOURCE CONTROL
==============================================================
USE SupportDB --[147]
*/

	SET NOCOUNT ON
	DECLARE @DayNumber int = DATEPART(dw,GETDATE())
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=0, @BotID=11, @StartTime='2014-05-29 12:15:55.130', @EndTime='2014-05-29 12:15:55.130'
	IF @IO = 0 AND @BotID IS NOT NULL AND @StartTime IS NOT NULL AND @EndTime IS NOT NULL -- !!!!!!!!!!!! KEEP  THIS !!!!!!!!!!
	BEGIN -- 'Timer Tick Registrate'
		INSERT bot_exec_history (BotID, StartTime, EndTime, TaskID)
		SELECT @BotID, @StartTime, @EndTime, @TaskID
		-----------------
		DELETE bot_exec_history WHERE TimeAdded < DATEADD(MONTH, -3, GETDATE())
		-- Registrate Last Work Bots
		UPDATE bots SET LastStartTime=StartTime, LastEndTime=EndTime
		FROM bots (nolock) b 
		JOIN (
			SELECT beh.BotID, beh.StartTime, beh.EndTime
			FROM bot_exec_history (nolock) beh
			JOIN (
				SELECT BotID, MAX(ID) as ID FROM bot_exec_history (nolock) GROUP BY BotID
			) as T ON T.ID = beh.ID
		) as T ON T.BotID = b.ID
		WHERE ISNULL(b.LastStartTime, '1900-01-01') <> T.StartTime AND ISNULL(b.LastEndTime, '1900-01-01') <> T.EndTime
		
		UPDATE bot_tasks SET RelayRace = 1
		FROM bot_tasks bt (nolock)
		INNER JOIN bot_task_relay_races btr (nolock) ON btr.BotID = @BotID AND btr.RelayRaceTaskID = bt.ID
		---------------
		GOTO ENDPROCEDURE
	END
	--MultiTask_BotLoader @IO=0
	----------------------------------------------------------
	/*
	DECLARE @StartTime datetime = GETDATE()
	EXEC MultiTask_BotLoader @IO=1, @StartTime=@StartTime, @BotID=2
	*/
	IF @IO = 1 AND (@BotID IN (2,8) OR @BotID IS NULL)
	BEGIN
		IF @BotID IS NULL SET @BotID = 2
		INSERT bot_exec_history (BotID, StartTime, EndTime, TaskID) VALUES(1, @StartTime, @StartTime, NULL)
		IF OBJECT_ID('TempDB..#LongWaitTasks') IS NOT NULL DROP TABLE #LongWaitTasks
		SELECT * INTO #LongWaitTasks FROM bot_tasks (nolock) WHERE Locked IS NULL AND PreLocked IS NOT NULL AND PreLocked < DATEADD(MINUTE,-5,GETDATE()) AND Disabled = 0
		IF EXISTS(SELECT * FROM #LongWaitTasks)
		BEGIN
			DECLARE @PreLocked_TaskID int 
			DECLARE #curs_PreLocked CURSOR FOR
			SELECT ID as PreLocked_TaskID FROM #LongWaitTasks 
			OPEN #curs_PreLocked
			FETCH #curs_PreLocked INTO @PreLocked_TaskID
			WHILE @@FETCH_STATUS = 0
			BEGIN
				UPDATE bot_tasks SET PreLocked = NULL WHERE ID = @PreLocked_TaskID
				FETCH #curs_PreLocked INTO @PreLocked_TaskID
			END
			CLOSE #curs_PreLocked
			DEALLOCATE #curs_PreLocked
		END
		/*
		DECLARE @DayNumber int = DATEPART(dw,GETDATE()) SELECT @DayNumber
		--*/
		--STOP
		SELECT DISTINCT ts.TaskID
		FROM subsystem_task_schedules (nolock) ts
		JOIN bot_tasks t (nolock) ON  t.ID = ts.TaskID AND t.Disabled = 0 AND t.PreLocked IS NULL AND t.Locked IS NULL AND t.BotID = @BotID
		AND 1 = CASE 
			WHEN UseRelayRace = 1 AND RelayRace = 1 THEN 1 
			WHEN UseRelayRace = 0 AND RelayRace = 0 THEN 1 
			ELSE 0 
		END
		JOIN bot_task_ssts ssts (nolock) ON ssts.TaskID = t.ID AND ssts.SubSystemTaskScheduleID = ts.ID
		WHERE ts.SubSystemID = 2 AND ts.Executed = 0 AND ts.StartTime IS NOT NULL AND ts.StartTime < GETDATE()
		AND CONVERT(varchar(9),getdate(),8) BETWEEN ISNULL(ts.FromTime,DateAdd(minute,-1,getdate())) AND ISNULL(ts.ToTime, DateAdd(minute,1,getdate()))
		AND 1 = CASE
			WHEN NoMonday = 1		AND @DayNumber = 2 THEN 0
			WHEN NoTuesday = 1		AND @DayNumber = 3 THEN 0
			WHEN NoWednesday = 1	AND @DayNumber = 4 THEN 0
			WHEN NoThursday = 1		AND @DayNumber = 5 THEN 0
			WHEN NoFriday = 1		AND @DayNumber = 6 THEN 0
			WHEN NoSaturday = 1		AND @DayNumber = 7 THEN 0
			WHEN NoSunday = 1		AND @DayNumber = 1 THEN 0
			ELSE 1
		END
		--AND t.ID = 108
		-----------------
		GOTO ENDPROCEDURE
	END
	--MultiTask_BotLoader @IO=1
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=2, @TaskID=1
	--SELECT TOP 10 * FROM bot_tasks (nolock) WHERE ID=1
	IF @IO = 2 AND @TaskID IS NOT NULL	--PreLocked
	BEGIN
		UPDATE bot_tasks SET PreLocked = getdate() WHERE ID = @TaskID
		-----------------
		GOTO ENDPROCEDURE
	END
	--MultiTask_BotLoaded @IO=2
	----------------------------------------------------------
	--MultiTask_BotLoaded @IO=3
	IF @IO = 3 AND @TaskID IS NOT NULL AND @ComputerProcessID IS NOT NULL
	BEGIN
		UPDATE bot_tasks SET Locked = getdate(), LockedComputerProcessID = @ComputerProcessID WHERE ID = @TaskID
		-----------------
		GOTO ENDPROCEDURE
	END
	--MultiTask_BotLoader @IO=3
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=4
	IF @IO = 4 AND @TaskID IS NOT NULL AND @BotID is NOT NULL --Finished
	AND @StartTime IS NOT NULL AND @EndTime IS NOT NULL
	BEGIN
		UPDATE bot_tasks SET PreLocked=NULL, Locked=NULL WHERE ID = @TaskID
		UPDATE subsystem_task_schedules SET Executed=1 WHERE TaskID = @TaskID AND SubSystemID = 2
		INSERT bot_exec_history (BotID, StartTime, EndTime, TaskID)
		SELECT @BotID, @StartTime, @EndTime, @TaskID
		UPDATE bots SET LastStartTime=@StartTime, LastENdTime=@EndTime WHERE ID = @BotID
		-----------------
		GOTO ENDPROCEDURE
	END
	--MultiTask_BotLoader @IO=4
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=5, @TaskID=58, @Debug=1
	IF @IO = 5
	BEGIN
		SELECT TOP 1 InstructionXml FROM bot_tasks (nolock) WHERE ID = @TaskID
		-----------------
		GOTO ENDPROCEDURE
	END
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=6, @TaskID=58
	--MultiTask_BotLoader @IO = 6, @TaskID = 108
	IF @IO = 6 AND @TaskID IS NOT NULL
	BEGIN
		SELECT TOP 1 TaskTypeID FROM bot_tasks (nolock) WHERE ID = @TaskID
		UPDATE bot_tasks SET TaskTypeIDGot = GETDATE() WHERE ID = @TaskID
		-----------------
		GOTO ENDPROCEDURE
	END
	----------------------------------------------------------
	--MultiTask_BotLoader @IO=7, @TaskID=58 --FINISH TASK
	IF @IO = 7 AND @TaskID IS NOT NULL
	BEGIN
		UPDATE subsystem_task_schedules SET Executed = 1 WHERE SubSystemID = 2 AND TaskID = @TaskID
		UPDATE bot_tasks SET PreLocked = NULL, Locked = NULL, LockedComputerProcessID = NULL WHERE ID = @TaskID
		UPDATE bot_tasks SET RelayRace = 0 WHERE ID = @TaskID AND UseRelayRace = 1
		--
		UPDATE bot_tasks SET RelayRace=1
		FROM bot_tasks t (nolock)
		JOIN bot_task_relay_races trr (nolock) ON trr.TaskID = @TaskID AND trr.RelayRaceTaskID = t.ID
		-----------------
		GOTO ENDPROCEDURE
	END

ENDPROCEDURE:
GO
