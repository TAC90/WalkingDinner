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