﻿using System;
using System.Text;
using VelocityCoders.LotteryPractice.BLL;
using System.Collections;
using System.Collections.Generic;
using VelocityCoders.LotteryPractice.Models;


namespace VelocityCoders.LotteryPractice.Webforms.Admin
{
    public partial class AddLotteryGameResult : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleCaption.Text = _PageTitleResult;
        }


        private const string _PageTitleResult = "Add Game Result";


        //========   CLICK-BUTTON EVENT HANDLER    ===========\\

        protected void btnSubmitResult(object sender, EventArgs e)
        {
            //==  [1] NEED TO CAPTURE FORM DATA FOR EACH INPUT FIELD  ==\\
            GameResultCollection CollectFormResult = new GameResultCollection();
            int totalGameBalls = GameResultAddBLL.TotalOfGameBalls(drpListGameName.SelectedValue.ToLower());

            //==  [2]. GO TO BLL
            CaptureFormInputValues();


            //==  WORK ON MOVING CODE TO BUSINESS LOGIC LAYER  ==\\
            //GameResultCollection gameResultList = new GameResultCollection();
            //List<string> displayResult = new List<string>();
            //int ballCount = (int)BallQuantity.Seven;



            //for (int i = 0; i < ballCount; i++)
            //{
            //    //==  SET AND RETURN AN INSTANCE OF GAME RESULT CLASS  ==\\
            //    gameResultList.Add(CaptureFormValues(i));
            //    displayResult.Add(CompileList(gameResultList, i, ballCount));
            //}

            //lblMessage.Text = string.Empty;
            //displayResultOnFrontPage(displayResult);

        }

        //=====  METHOD FOR GETTING BALL NUMBERS AND LOTTERY VALUES INTO A LIST ITEM  =====//
        protected string CompileList(GameResultCollection gameResultList, int i, int ballCount)
        {
            string compileResult = "";

            int currentItem = gameResultList[i].BallNumber;
            string currentLotteryName = gameResultList[i].LotteryName;

            if (i == 0)
            {
                compileResult = currentLotteryName + " || " + currentItem.ToString();
            }
            else
                compileResult = currentItem.ToString() + " || ";

            return compileResult;
        }

        //====== METHOD TO VERIFY THE RESULTS BY PRINTING OUT TO WEB - PAGE ========\\
        protected void displayResultOnFrontPage(List<string> displayResult)
        {
            foreach (string item in displayResult)
            {
                lblMessage.Text += item;
            }

        }

        //====== METHOD TO CAPTURE WEB-FORM INPUT  ========\\
        private GameResult CaptureFormInputValues()
        {
            GameResult theFormResult = new GameResult();

            //==  SET VARIABLES FOR EACH BALL  ==//
            int ballOne = BallNumber_1.Text.ToInt();
            int ballTwo = BallNumber_2.Text.ToInt();
            int ballThree = BallNumber_3.Text.ToInt();
            int ballFour = BallNumber_4.Text.ToInt();
            int ballFive = BallNumber_5.Text.ToInt();
            int ballSix = SpecialBallNumber.Text.ToInt();
            int ballSeven = drpListMultiplier.Text.ToInt();

            //==  SET PROPERTY VALUES FOR INSTANCE OF "GAME CLASS"  ==//
            theFormResult.LotteryName = drpListGameName.SelectedValue;
            theFormResult.DrawDate = calDrawingDate.SelectedDate;
            theFormResult.Jackpot = txtJackpotAmount.Text;

            //==  SET HASBALL PROPERTIES FOR INSTANCE OF GAME CLASS  ==//

            //LotteryName testForSpecialBall = (LotteryName)Enum.Parse(typeof(LotteryName), theFormResult.LotteryName.ToString());
            switch (theFormResult.LotteryName)
            {
                case GameName._Powerball:
                case GameName._Megaball:
                    theFormResult.HasSpecialBall = true;
                    theFormResult.IsRegularBall = true;
                    break;
                case GameName._NorthstarCash:
                case GameName._Gopher5:
                    theFormResult.HasSpecialBall = false;
                    theFormResult.IsRegularBall = true;
                    break;
            }

            //==  SET BALL TYPE I.E. REGULAR, POWERBALL, MEGABALL, ETC  ==\\
            if (ballOne > 0 ) {
                theFormResult.BallNumber = ballOne;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (ballTwo > 0 ) {
                theFormResult.BallNumber = ballTwo;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (ballThree > 0 ) {
                theFormResult.BallNumber = ballThree;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (ballFour > 0 ) {
                theFormResult.BallNumber = ballFour;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
            else if (ballFive > 0 ) {
                theFormResult.BallNumber = ballFive;
                theFormResult.BallTypeId = (int)BallType.Regularball;
            }
                //== CHECK BALL #6 || SPECIAL BALL TYPE
            else if (ballSix > 0 )
            {
                switch(theFormResult.LotteryName)
                {
                    case GameName._Powerball:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Powerball;
                        break;
                    case GameName._Megaball:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Megaball;
                        break;
                    default:
                        theFormResult.BallNumber = ballSix;
                        theFormResult.BallTypeId = (int)BallType.Specialball;
                        break;
                }  
            }
                //== CHECK BALL #7 || MULTIPLIER BALL TYPE
            else 
            {
                theFormResult.BallNumber = ballSeven;
                theFormResult.BallTypeId = (int)BallType.Multiplierball;
            }

            return theFormResult;
        }

        //protected GameResult CaptureFormValues(int i)
        //{
        //    GameResult addGameResultData = new GameResult();

        //    addGameResultData.LotteryName = drpListGameName.SelectedValue;
        //    addGameResultData.DrawDate = calDrawingDate.SelectedDate;
        //    addGameResultData.Jackpot = txtJackpotAmount.Text;
        //    if (i == 0) { addGameResultData.BallNumber = BallNumber_1.Text.ToString().ToInt(); }
        //    if (i == 1) { addGameResultData.BallNumber = BallNumber_2.Text.ToString().ToInt(); }
        //    if (i == 2) { addGameResultData.BallNumber = BallNumber_3.Text.ToString().ToInt(); }
        //    if (i == 3) { addGameResultData.BallNumber = BallNumber_4.Text.ToString().ToInt(); }
        //    if (i == 4) { addGameResultData.BallNumber = BallNumber_5.Text.ToString().ToInt(); }
        //    if (i == 5) { addGameResultData.BallNumber = SpecialBallNumber.Text.ToString().ToInt(); }
        //    if (i == 6) { addGameResultData.BallNumber = drpListMultiplier.SelectedValue.ToInt(); }

        //    return addGameResultData;

        //}



    }
}