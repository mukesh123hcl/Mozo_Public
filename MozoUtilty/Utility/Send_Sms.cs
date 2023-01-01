using System;
using Microsoft.AspNetCore.Mvc;

using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
namespace MozoUtilty.Utility
{
	public class Send_Sms
	{
		public static bool SMS_send(string mobile,string OTP,string name)
		{
			const string accountSid = "ACafbd8e60d1b56986b109fc722ad50305";
			const string authToken = "c9ba44758ab12e0ac5a7298362aee654";
			TwilioClient.Init(accountSid, authToken);

			var to = new PhoneNumber("+91" + mobile);
			var message = MessageResource.Create(
				to,
				from: new PhoneNumber("+12029465916"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).  
				body: $"Hello {name} !! Welcome to Mozo your OTP is {OTP}. Never share with any one");

			return true;
		}
	}
}
