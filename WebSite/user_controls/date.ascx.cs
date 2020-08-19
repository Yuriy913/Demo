using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class user_controls_date : System.Web.UI.UserControl
{

    public void setName(string Name) 
    {
        dateLabel.Text = Name;
        return;
    }

    public string getISODate()
    {
        return Year.SelectedValue + Month.SelectedValue + Day.SelectedValue;
    }
    
    public void setDate(DateTime tDate)
    {
        //string tDay, 
            string tMonth, tYear;

        Create_Days_Items(tDate.Year, tDate.Month, tDate.Day);
        tMonth = tDate.Month.ToString();
        if (tMonth.Length == 1)
        {
            tMonth = "0" + tMonth;
        }

        foreach (ListItem item in Month.Items)
        {
            if (item.Value == tMonth)
            {
                item.Selected = true;
            }
            else
            {
                item.Selected = false;
            }

        }

        tYear = tDate.Year.ToString();
        foreach (ListItem item in Year.Items)
        {
            if (item.Value == tYear)
            {
                item.Selected = true;
            }
            else
            {
                item.Selected = false;
            }
        }
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Days
            Day.Items.Clear();
            string dValue;
            for (int d = 1; d < 32; d++)
            {
                if (d.ToString().Length > 1)
                {
                    dValue = d.ToString();
                }
                else
                {
                    dValue = "0" + d.ToString();
                }
                ListItem nli = new ListItem(d.ToString(), dValue);
                Day.Items.Add(nli);
            }
            // Months
            DateTime ndt = new DateTime(1900, 1, 1);
            Month.Items.Clear();
            string mValue;
            for (int m = 1; m < 13; m++)
            {
                if (m.ToString().Length > 1)
                {
                    mValue = m.ToString();
                }
                else
                {
                    mValue = "0" + m.ToString();
                }

                ListItem nli = new ListItem(ndt.ToString("MMMM"), mValue);
                Month.Items.Add(nli);
                ndt = ndt.AddMonths(1);
            }

            // Years
            DateTime cdt = DateTime.Now;
            Year.Items.Clear();
            for (int y = 1; y < 11; y++)
            {
                ListItem nli = new ListItem(cdt.Year.ToString(), cdt.Year.ToString());
                Year.Items.Add(nli);
                cdt = cdt.AddYears(-1);
            }
        }

    }

    protected void Create_Days_Items(int Year, int Month, int selectedDay)
    {

        int daysInMonth;
        string strSelectedDay, dValue;

        daysInMonth = DateTime.DaysInMonth(Year, Month);
        if (selectedDay > daysInMonth)
        {
            selectedDay = daysInMonth;
        }

        if (selectedDay.ToString().Length > 1)
        {
            strSelectedDay = selectedDay.ToString();
        }
        else
        {
            strSelectedDay = "0" + selectedDay.ToString();
        }

        Day.Items.Clear();
        for (int d = 1; d <= daysInMonth; d++)
        {
            if (d.ToString().Length > 1)
            {
                dValue = d.ToString();
            }
            else
            {
                dValue = "0" + d.ToString();
            }

            ListItem nli = new ListItem(d.ToString(), dValue);

            if (dValue == strSelectedDay)
            {
                nli.Selected = true;
            }
            Day.Items.Add(nli);
        }
    }


    protected void Month_SelectedIndexChanged(object sender, EventArgs e)
    {
        Create_Days_Items(Convert.ToInt32(Year.SelectedValue),
        Convert.ToInt32(Month.SelectedValue), Convert.ToInt32(Day.SelectedValue));
    }
    protected void Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        Create_Days_Items(Convert.ToInt32(Year.SelectedValue),
        Convert.ToInt32(Month.SelectedValue), Convert.ToInt32(Day.SelectedValue));
    }
}
