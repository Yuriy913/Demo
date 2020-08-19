/*<!--*/
function myclock(){

function getBelSummerStartDate()
{
currDate = new Date();
var i = 31;
do
{
   summerStartDate = new Date(currDate.getYear(), 2, i, 2);
   if (summerStartDate.getDay() == 0)
   {
   break;
   }
   i--;
} while (i > 0);
return summerStartDate;
}

function getBelSummerEndDate()
{
currDate = new Date();
var i = 31;
do
{
   summerEndDate = new Date(currDate.getYear(), 9, i, 3);
   if (summerEndDate.getDay() == 0)
   {
   break;
   }
   i--;
} while (i > 0);
return summerEndDate;
}


function getUSASummerStartDate()
{
currDate = new Date();
var i = 1;
var flag = 0;
do
{
   summerStartDate = new Date(currDate.getYear(), 2, i, 2);
   if (summerStartDate.getDay() == 0)
   {
   if (flag != 0) {break;}
   flag = 1;
   }
   i++;
} while (i <= 31 );
return summerStartDate;
}

function getUSASummerEndDate()
{
currDate = new Date();
var i = 1;
do
{
   summerEndDate = new Date(currDate.getYear(), 10, i, 2);
   if (summerEndDate.getDay() == 0)
   {
   break;
   }
   i++;
} while (i <= 31 );
return summerEndDate;
}

function getdatastr(GMThours)
{

GMThours = GMThours;

getUSASummerEndDate();

dataUTC = new Date();
dataUTC.setMinutes(dataUTC.getMinutes() + dataUTC.getTimezoneOffset());
newdata = new Date(dataUTC);

if ((GMThours == 2)&& (newdata > getBelSummerStartDate()) && (newdata < getBelSummerEndDate())) // Bel summer time
{
    GMThours = GMThours + 1;
}

if ((GMThours == -5)&& (newdata > getUSASummerStartDate()) && (newdata < getUSASummerEndDate())) // USA summer time
{
    GMThours = GMThours+1;
}

newdata.setHours(newdata.getHours() + GMThours);
monts = newdata.getMonth() + 1;
days = newdata.getDate();
hours = newdata.getHours();
mins = newdata.getMinutes();
secs = newdata.getSeconds();
if (monts < 10) {monts = "0" + monts}
if (days < 10) {days = "0" + days}
if (hours < 10) {hours = "0" + hours}
if (mins < 10) {mins = "0" + mins}
if (secs < 10) {secs = "0" + secs}
datastr = monts + "/" + days + "/" + newdata.getYear() + '<br>' + hours + ":" + mins + ":" + secs;
return datastr;
}
if (document.layers){
document.getElementById(_clientIds['clockexam_bel']).document.write(getdatastr(2))
document.getElementById(_clientIds['clockexam_bel']).document.close()
document.getElementById(_clientIds['clockexam_usa']).document.write(getdatastr(-5))
document.getElementById(_clientIds['clockexam_usa']).document.close()
}
else
{
document.getElementById(_clientIds['clockexam_bel']).innerHTML= getdatastr(2)
document.getElementById(_clientIds['clockexam_usa']).innerHTML= getdatastr(-5)
}
setTimeout("myclock()",1000)
}
//-->

function ColorRow(row)
{
	row.style.backgroundColor = "#FFFFFF";
}

function UnColorRow(row)
{
	row.style.backgroundColor = "#DEDFDE";
}

function ColorUncolorTextBox(txtControl)
{
	if(txtControl != null)
	{
		if(txtControl.value.length != 0)
		{
			txtControl.style.backgroundColor = "#E0EEE0";
		}
		else
		{
			txtControl.style.backgroundColor = "#FFFFFF";
		}
	}
}

function TextBoxOnFocusPrompt(txtControl, promptText)
{
	if(txtControl != null)
	{
		if(txtControl.value == promptText)
		{
			txtControl.value = "";
			txtControl.style.color = "black";
		}
	}
}

function TextBoxOnBlurPrompt(txtControl, promptText)
{
	if(txtControl != null)
	{
		if(txtControl.value.length == 0)
		{
			txtControl.value = promptText;
			txtControl.style.color = "grey";
		}
	}
}