//var modal = document.getElementById("myModal");

//// Get the button that opens the modal
//var btn = document.getElementById("myBtn");

//// Get the <span> element that closes the modal
//var span = document.getElementsByClassName("close")[0];

//// When the user clicks on the button, open the modal
//btn.onclick = function() {
//  modal.style.display = "block";
//}

//// When the user clicks on <span> (x), close the modal
//span.onclick = function() {
//  modal.style.display = "none";
//}

//// When the user clicks anywhere outside of the modal, close it
//window.onclick = function(event) {
//  if (event.target == modal) {
//    modal.style.display = "none";
//  }
//}
var Alert = new CustomAlert();


function CustomAlert() {

    this.render = function () {

        //Show Modal

        let popUpBox = document.getElementById('popUpBox');

        popUpBox.style.display = "block";

        //Close Modal
        document.getElementById('closeModal').innerHTML = '<button onclick="Alert.ok()">OK</button>';

    }



    this.ok = function () {

        document.getElementById('popUpBox').style.display = "none";

        document.getElementById('popUpOverlay').style.display = "none";

    }


}