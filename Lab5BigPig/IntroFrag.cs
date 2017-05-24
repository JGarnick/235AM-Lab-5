using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Preferences;

namespace Lab5BigPig
{
    public class IntroFrag : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("FragName", "IntroFrag");
            editor.Apply();
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.IntroFrag, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}