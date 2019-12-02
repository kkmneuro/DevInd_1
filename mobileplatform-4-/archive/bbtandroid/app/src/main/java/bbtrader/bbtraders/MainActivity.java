package bbtrader.bbtraders;

import android.app.ProgressDialog;
import android.content.res.Configuration;
import android.graphics.Bitmap;
import android.net.ConnectivityManager;
import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends ActionBarActivity {

    private WebView mWebview;
    private TextView urlEditText;
    private ProgressBar progress;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        if(isInternetOn()) {

            final ProgressDialog pd = ProgressDialog.show(this, "", "Please wait...", true);
            mWebview = (WebView) findViewById(R.id.webView);

            mWebview.getSettings().setJavaScriptEnabled(true); // enable javascript
            //  mWebview.getSettings().setLoadWithOverviewMode(true);
            //  mWebview.getSettings().setUseWideViewPort(true);
            // mWebview.getSettings().setBuiltInZoomControls(true);


            mWebview.clearCache(true);

           // mWebview.clearCache(false);
            mWebview.setWebViewClient(new WebViewClient() {
                public void onReceivedError(WebView view, int errorCode, String description, String failingUrl) {
                    // Toast.makeText(activity_main, description, Toast.LENGTH_SHORT).show();
                }

                @Override
                public void onPageStarted(WebView view, String url, Bitmap favicon) {
                    pd.show();
                }

                @Override
                public void onPageFinished(WebView view, String url) {
                    pd.dismiss();
                    String webUrl = mWebview.getUrl();
                }
            });
            mWebview.loadUrl("http://78.47.54.100/BBTrader.php");

          //  CookieManager.getInstance().setAcceptCookie(true);
          //  CookieManager.getInstance().setAcceptThirdPartyCookies(mWebview,true);
        }
        else
        {
            TextView  tv = (TextView) findViewById(R.id.networkOffTv);
            tv.setText("Sorry...Please check your network connection.");

        }
    }

    public final boolean isInternetOn() {

        // get Connectivity Manager object to check connection
        ConnectivityManager connec =
                (ConnectivityManager)getSystemService(getBaseContext().CONNECTIVITY_SERVICE);

        // Check for network connections
        if ( connec.getNetworkInfo(0).getState() == android.net.NetworkInfo.State.CONNECTED ||
                connec.getNetworkInfo(0).getState() == android.net.NetworkInfo.State.CONNECTING ||
                connec.getNetworkInfo(1).getState() == android.net.NetworkInfo.State.CONNECTING ||
                connec.getNetworkInfo(1).getState() == android.net.NetworkInfo.State.CONNECTED ) {

            // if connected with internet

            //  Toast.makeText(this, " Connected ", Toast.LENGTH_LONG).show();
            return true;

        } else if (
                connec.getNetworkInfo(0).getState() == android.net.NetworkInfo.State.DISCONNECTED ||
                        connec.getNetworkInfo(1).getState() == android.net.NetworkInfo.State.DISCONNECTED  ) {

            //      Toast.makeText(this, " Not Connected ", Toast.LENGTH_LONG).show();
            return false;
        }
        return false;
    }


    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);

        // webview.setVisibility(View.VISIBLE);
        // Checks the orientation of the screen
        if (newConfig.orientation == Configuration.ORIENTATION_LANDSCAPE) {
            Toast.makeText(this, "landscape", Toast.LENGTH_SHORT).show();
        } else if (newConfig.orientation == Configuration.ORIENTATION_PORTRAIT) {
            Toast.makeText(this, "portrait", Toast.LENGTH_SHORT).show();
        }
    }
}
