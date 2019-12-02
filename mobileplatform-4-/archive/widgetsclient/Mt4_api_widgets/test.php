<!DOCTYPE html>
<html>
<head>
</style>
  <!-- Don't forget to include jQuery ;) -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.8.0/jquery.modal.js" rel="modal:open" type="text/javascript" charset="utf-8"></script>
</head>
<body>

  <!-- Modal HTML embedded directly into document -->
  <div id="ex1" style="display:none;">
    <p>Thanks for clicking.  That felt good.  <a href="#" rel="modal:close">Close</a> or press ESC</p>
  </div>

  <!-- Link to open the modal -->
  <p><a href="#ex1" rel="modal:open">Open Modal</a></p>

</body>
</html>