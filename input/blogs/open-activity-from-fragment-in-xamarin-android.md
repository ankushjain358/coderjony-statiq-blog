Title: Open activity from fragment in Xamarin Android
Published: 10/09/2018
Author: Ankush Jain
IsActive: true
Tags:
  - Android
---
You can use below code to open an activity from fragment in Xamarin Android.

```cs
Intent intent = new Intent(this.Activity, typeof(HomeDemo));
StartActivity(intent);
```

Here is the complete code:

```cs
public class HomeFragment : Fragment
{
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.HomeFragmentLayout, container, false);

            Button btnHome = view.FindViewById<Button>(Resource.Id.btnHome);
            btnHome.Click += BtnHome_Click;

            return view;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(HomeDemo));
            StartActivity(intent);
        }
}
```

                