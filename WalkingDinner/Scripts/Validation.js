function zipcodeCheck() {
    var patt = /^\d{4}[ -]?[A-Z]{2}$/i;

    var zipcodeBox = document.getElementById("zipcodeBox");

    var result = patt.exec(zipcodeBox.value);
    //Print in console for clarity/testing
    console.log("test for '" + zipcodeBox.value + "' = " + result);

    var messageBox = document.getElementById("zipcodeError");

    if (result == null && zipcodeBox.value != "") {
        //change color to red to highlight it
        messageBox.style.color = "red";
        messageBox.innerHTML = "Invalid zipcode!";
    }
}

function telCheck() {
    var patt = /^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\.\/0-9]*$/;

    var zipcodeBox = document.getElementById("telBox");

    var result = patt.exec(telBox.value);
    //Print in console for clarity/testing
    console.log("test for '" + telBox.value + "' = " + result);

    var messageBox = document.getElementById("telError");

    if (result == null && zipcodeBox.value != "") {
        //change color to red to highlight it
        messageBox.style.color = "red";
        messageBox.innerHTML = "Invalid phone number!";
    }
}

var previousScheduleID = 0;
var selectedScheduleColor = "green";

//function selectSchedule2(scheduleID) {

//    var selectedSchedule = document.getElementById(scheduleID);
//    selectedSchedule.style.backgroundColor = selectedScheduleColor;

//    if (previousScheduleID != null){
//        var previousSchedule = document.getElementById(previousScheduleID);
//        console.log(previousSchedule.style.backgroundColor);
//        if (selectedSchedule != previousSchedule) {
//            //previousSchedule.style.backgroundColor = "";
//            previousSchedule.removeAttribute("style");
//        }
//    }
//    previousScheduleID = scheduleID;
//}

function selectSchedule(scheduleID) {
    var selectedSchedule = document.getElementById(scheduleID);
    var button = document.getElementById("selectSchedule");
    var selectedHref = button.getAttribute("href");

    if (previousScheduleID != 0) { //Something else was clicked first, undo previous
        var previousSchedule = document.getElementById(previousScheduleID);
        previousSchedule.removeAttribute("style");
    }
    if (previousScheduleID == scheduleID) { //Clicked same one twice
        //console.log("Clicked same one");
        selectedSchedule.removeAttribute("style");
        previousScheduleID = 0;
        button.setAttribute("hidden", "true");
    }
    else {
        selectedSchedule.style.backgroundColor = selectedScheduleColor;
        previousScheduleID = scheduleID;
        //console.log("Pass along this ID: " + scheduleID);
        selectedHref = selectedHref.substring(0, selectedHref.lastIndexOf('=')+1)+scheduleID;
        console.log(selectedHref);
        button.setAttribute("href", selectedHref);
        button.removeAttribute("hidden");
    }
}