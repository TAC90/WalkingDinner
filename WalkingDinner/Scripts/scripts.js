//Validation scripts
function zipCheck() {
    var patt = /^\d{4}[ -]?[A-Z]{2}$/i;

    var zipcodeBox = document.getElementById("zipBox");

    var result = patt.exec(zipcodeBox.value);
    //Print in console for clarity/testing
    console.log("test for '" + zipcodeBox.value + "' = " + result);

    var messageBox = document.getElementById("zipError");

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
//--------------------------//

//Selection of schedule
var previousScheduleID = 0;
var selectedScheduleColor = "green";

function selectSchedule(scheduleID) {
    var selectedSchedule = document.getElementById(scheduleID);
    if (selectedSchedule.className != "full") {
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
            selectedHref = selectedHref.substring(0, selectedHref.lastIndexOf('=') + 1) + scheduleID;
            console.log(selectedHref);
            button.setAttribute("href", selectedHref);
            button.removeAttribute("hidden");
        }
    }
}


// Enable/Disable partner's input on checkbox input
function isSolo() {
    if (document.getElementById("soloCheckBox").checked) {
        document.getElementById("firstNamePartnerTB").disabled = true;
        document.getElementById("middleNamePartnerTB").disabled = true;
        document.getElementById("lastNamePartnerTB").disabled = true;
    }
    else {
        document.getElementById("firstNamePartnerTB").disabled = false;
        document.getElementById("middleNamePartnerTB").disabled = false;
        document.getElementById("lastNamePartnerTB").disabled = false;
    }
}

function listCheck() {
    var list = document.getElementsByClassName("participantList");
    for (var i = 0; i < list.length; i++) {
        //console.log(list[i].getAttribute("id"));
    }
}

function generateProgram() {
    var program = "";
    let participantList = document.getElementsByClassName("participantList"); //Can't be randomized because exists out of DOM objects
    var groupSize = document.getElementById("groupSize").getAttribute("value");
    var participantAmount = participantList.length;

    var indexArray = []; //Create new array to randomize index
    for (var i = 0; i < participantAmount; i++) {
        indexArray.push(i);
    }
    indexArray.sort(function (a,b) {
        return 0.5 - Math.random();
    })

    for (var c = 0; c < groupSize; c++) {
        //Courses
        //console.log("Course " + (c + 1))
        for (var g = 0; g < participantAmount / groupSize; g++) {
            //Groups
            var group = "";
            for (var i = 0; i < groupSize; i++) {
                var index = (c * (participantAmount)) + (g * groupSize) + i + 1; //Set index (position)
                var seq = (g * groupSize) + i; //Build up ID sequence
                var offset = (((i * groupSize) + 1 ) * c) //Create offset per participant
                var id = (seq + offset) % participantAmount; //Create ID according to sequence and offset
                var participant = participantList[indexArray[id]]; //Get participant by id through randomizer

                populateProgram(index, participant.getAttribute("name"));

                program += (index + ":" + indexArray[id] + ","); //Create array-string step by step

                //console.log("Sequence: " + seq + " | Offset: " + offset + " | Id: " + id); //Check number situation
                //console.log("i: " + index + " - p: " + participant.getAttribute("id") + " - " + participant.getAttribute("name"));
                //group += (participant.getAttribute("name") + ", ") //Per group logging
            }
            //console.log(group); //Groups made
        }

    }
    program = document.getElementById("scheduleId").value + "|" + program;
    document.getElementById("programData").value = program;
    document.getElementById("saveProgram").toggleAttribute("disabled", false);
    console.log(program);    
}

function populateProgram(id, p) { //Insert participant names into table
    document.getElementById("p"+id).innerHTML = p;
}

function saveProgram() {
    $.ajax({
        type: "POST",
        url: "",
        data: {
            data: $("#programData").val()
        },
        dataType: 'text',
        success: function (response) {
            //alert(response)
            console.log("Success")
            window.location.href = response.redirectToUrl; //Get redirect from controller
        }
    });
};

function populateProgramFromString() {
    var programData = document.getElementById("programData").value;
    var programArray = programData.split(",");
    let participantList = document.getElementsByClassName("participantList");

    for (var i = 0; i < programArray.length - 1; i++) {
        var participant = programArray[i].split(":");
        populateProgram(participant[0], participantList[participant[1]].getAttribute("name"));
    }
}
