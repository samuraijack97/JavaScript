using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JavaScriptSite
{
    public partial class createtestquestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlQuestionType.SelectedIndex != 0)
            {
                if (string.IsNullOrEmpty(txtQuestion.Text))
                {
                    litMessage.Text = "<p style='font-weight: bold; color: red;'>Please enter a question or answer(s).</p>";
                    return;
                }

                if (ddlQuestionType.SelectedIndex == 1) // multiple choice
                {
                    if (string.IsNullOrEmpty(txtAnswer.Text) || string.IsNullOrEmpty(txtAnswer1.Text) ||
                        string.IsNullOrEmpty(txtAnswer2.Text) || string.IsNullOrEmpty(txtAnswer3.Text))
                    {
                        litMessage.Text = "<p style='font-weight: bold; color: red;'>Please enter a question or answer(s).</p>";
                        return;
                    }
                    int questionID = 0;
                    questionID = (int)Database.ExecuteSQL("INSERT INTO Questions VALUES (@QuestionText, @QuestionType); SELECT SCOPE_IDENTITY();",
                        new SqlParameter("@QuestionText", txtQuestion.Text), 
                        new SqlParameter("@QuestionType", ddlQuestionType.SelectedValue));

                    int answer1 = 0, answer2 = 0, answer3 = 0, answer4 = 0;

                    answer1 = (int)Database.ExecuteSQL("INSERT INTO Choices VALUES (@QuestionAnswer);",
                        new SqlParameter("@QuestionAnswer", txtAnswer.Text));
                    answer2 = (int)Database.ExecuteSQL("INSERT INTO Choices VALUES (@QuestionAnswer);",
                        new SqlParameter("@QuestionAnswer", txtAnswer1.Text));
                    answer3 = (int)Database.ExecuteSQL("INSERT INTO Choices VALUES (@QuestionAnswer);",
                        new SqlParameter("@QuestionAnswer", txtAnswer2.Text));
                    answer4 = (int)Database.ExecuteSQL("INSERT INTO Choices VALUES (@QuestionAnswer);",
                        new SqlParameter("@QuestionAnswer", txtAnswer3.Text));

                    Database.ExecuteSQL("INSERT INTO QuestionChoiceMap VALUES (@QuestionID, @AnswerID, 0);",
                        new SqlParameter("@QuestionID", questionID),
                        new SqlParameter("@AnswerID", answer1));
                    Database.ExecuteSQL("INSERT INTO QuestionChoiceMap VALUES (@QuestionID, @AnswerID, 0);",
                        new SqlParameter("@QuestionID", questionID),
                        new SqlParameter("@AnswerID", answer2));
                    Database.ExecuteSQL("INSERT INTO QuestionChoiceMap VALUES (@QuestionID, @AnswerID, 0);",
                        new SqlParameter("@QuestionID", questionID),
                        new SqlParameter("@AnswerID", answer3));
                    Database.ExecuteSQL("INSERT INTO QuestionChoiceMap VALUES (@QuestionID, @AnswerID, 0);",
                        new SqlParameter("@QuestionID", questionID),
                        new SqlParameter("@AnswerID", answer4));
                }
                else if (ddlQuestionType.SelectedIndex == 2) // true/false
                {
                    if (string.IsNullOrEmpty(rdlTrueFalse.SelectedValue))
                    {
                        litMessage.Text = "<p style='font-weight: bold; color: red;'>Please enter a question or answer(s).</p>";
                        return;
                    }
                }
                else if (ddlQuestionType.SelectedIndex == 3) // short answer
                {
                    if (string.IsNullOrEmpty(txtAnswer.Text))
                    {
                        litMessage.Text = "<p style='font-weight: bold; color: red;'>Please enter a question or answer(s).</p>";
                        return;
                    }
                }
            }
            else
            {
                pnlQuestionAnswers.Visible = false;
                litMessage.Text = "<p style='font-weight: bold; color: red;'>Please select a question type.</p>";
            }
        }

        protected void ddlQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuestionType.SelectedIndex != 0)
            {
                pnlQuestionAnswers.Visible = true; // for all the answer types plus submit button
                if (ddlQuestionType.SelectedIndex == 1) // multiple choice
                {
                    pnlShortAnswerAnswer.Visible = true;
                    pnlTrueFalse.Visible = false;
                    pnlMulti.Visible = true;
                }
                else if (ddlQuestionType.SelectedIndex == 2) // true/false
                {
                    pnlShortAnswerAnswer.Visible = false;
                    pnlTrueFalse.Visible = true;
                    pnlMulti.Visible = false;
                }
                else if (ddlQuestionType.SelectedIndex == 3) // short answer
                {
                    pnlShortAnswerAnswer.Visible = true;
                    pnlTrueFalse.Visible = false;
                    pnlMulti.Visible = false;
                }
            }
            else
            {
                pnlQuestionAnswers.Visible = false;
                litMessage.Text = "<p style='font-weight: bold; color: red;'>Please select a question type.</p>";
            }
        }
    }
}