<%@ Page language="c#" %>
<script runat="server">
  
  void Page_Load(object sender, System.EventArgs e) {
    var identifier = "user_" + Guid.NewGuid();
    Sitecore.Analytics.Tracker.Current.Session.IdentifyAs("xdbdemo", identifier);
    //Sitecore.Analytics.Tracker.Current.EndTracking();
    //Session.Abandon();
    Response.Write(string.Format("Identified as '{0}'", identifier));
  }
  
</script>  
<!DOCTYPE html>
<html>
  <head>
    <title>end session</title>
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/default.css" rel="stylesheet">
  </head>
  <body>
  </body>
</html>