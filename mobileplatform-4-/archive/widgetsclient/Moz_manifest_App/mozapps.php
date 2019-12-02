<script type="application/javascript">
var request = window.navigator.mozApps.install("http://78.47.54.100/manifestwebapp.php");
request.onsuccess = function () {
  // Save the App object that is returned
  var appRecord = this.result;
  alert('Installation successful!');
};
request.onerror = function () {
  // Display the error information from the DOMError object
  alert('Install failed, error: ' + this.error.name);
};
</script>