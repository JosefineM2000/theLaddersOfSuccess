using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quots_CS : MonoBehaviour
{

    public List<string> quots = new List<string>();
    public static int count = 0;
    public TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start()
    {
        quots.Add("My biggest success is appreciating myself and the things that I do. - Josefine Mende");
        quots.Add("Success is how high you bounce when you hit bottom. - Gen. George Patton");
        quots.Add("Success is walking from failure to failure with no loss of enthusiasm. - Winston Churchill");
        quots.Add("The only place success comes before work is in the dictionary. - Vince Lombardi");
        quots.Add("Success usually comes to those who are too busy to be looking for it. - Henry David Thoreau");
        quots.Add("Success is not final; failure is not fatal: It is the courage to continue that counts. - Winston Churchill");
        quots.Add("Success seems to be connected with action. Successful people keep moving.They make mistakes but they don’t quit. - Conrad Hilton");
        quots.Add("Your attitude is either the lock on or key to your door of success. - Denis Waitley");
        quots.Add("There is only one success – to be able to spend your life in your own way. - Christopher Morley");
        quots.Add("Behind every successful man there’s a lot of unsuccessful years. - Bob Brown");
        quots.Add("The secret to success is to know something nobody else knows. - Aristotle Onassis");
        quots.Add("Success is a science; if you have the conditions, you get the result. - Oscar Wilde");
        quots.Add("Success is nothing more than a few simple disciplines, practiced every day. - Jim Rohn");
        quots.Add("Success comes from knowing that you did your best to become the best that you are capable of becoming. - John Wooden");
        quots.Add("Many of life’s failures are people who did not realize how close they were to success when they gave up. - Thomas Edison");
        quots.Add("Only those who dare to fail greatly can ever achieve greatly. - Robert F. Kennedy");
        quots.Add("You aren’t going to find anybody that’s going to be successful without making a sacrifice and without perseverance. - Lou Holtz");
        quots.Add("The ladder of success is best climbed by stepping on the rungs of opportunity. - Ayn Rand");
        quots.Add("Ambition is the path to success. Persistence is the vehicle you arrive in. - Bill Bradley");
        quots.Add("Accomplishing goals is not success. How much you expand in the process is. - Brianna Wiest");
        quots.Add("Success is to be measured not so much by the position that one has reached in life as by the obstacles which he has overcome. - Booker T. Washington");
        quots.Add("Success consists of getting up just one more time than you fall. - Oliver Goldsmith");
        quots.Add("Success is finding satisfaction in giving a little more than you take. - Christopher Reeve");
        quots.Add("It is better to fail in originality than to succeed in imitation. - Herman Melville");
        quots.Add("No-one knows what he can do until he tries. - Publilius Syrus");
        quots.Add("Don’t wish it were easier; wish you were better. - Jim Rohn");
        quots.Add("Only those who will risk going too far can possibly find out how far one can go. - T.S.Eliot");
        quots.Add("Some people dream of success, while other people get up every morning and make it happen. - Wayne Huizenga");
        quots.Add("Success is about doing the right thing, not about doing everything right. - Gary Keller");
        quots.Add("If your dreams don’t scare you, they are too small. - Richard Branson");
        quots.Add("You learn more in Failure than you ever do in success. - Jay-Z");

        if (count == quots.Count)
        {
            count = 0;
        }
        textField.text = quots[count];
        count++;
    }
}
