function toggleMultiplier(button)
{
    let otherButtonId = button.id === 'double' ? 'treble' : 'double';
    document.getElementById(otherButtonId).disabled = !document.getElementById(otherButtonId).disabled;
    document.getElementById('bullseyeThrow').disabled = !document.getElementById('bullseyeThrow').disabled;
    document.getElementById('outerBullThrow').disabled = !document.getElementById('outerBullThrow').disabled;
}

function handleThrow()
{
    let multiplier = 'S';
    let throwValue = document.getElementById('throwValue').value;
    let trebleValue = document.getElementById('treble').disabled ? false : true;
    let doubleValue = document.getElementById('double').disabled ? false : true;

    // if the throw value is empty alert the user and don't carry on
    // only do this if the throw value is not the bullseye or outer bull

    if (throwValue === "" && !bullValue && !outerBullThrow) {
        alert("Please enter a throw value");
        return;
    }

    if (trebleValue && !doubleValue) {
        multiplier = 'T';
    }
    else if (doubleValue && !trebleValue) {
        multiplier = 'D';
    }

    fetch('/RoundTheBoard/Throw', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({multiplier: multiplier, throwValue: throwValue})
    })
        .then(response => // redierct to the home page
            window.location.href = '/roundtheboard/index'
        )
        .catch(error => console.error('Error:', error));
}

function handleMiss()
{

    fetch('/RoundTheBoard/Throw', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({multiplier: "S", throwValue: "0"})
    })
        .then(response => // redierct to the home page
            window.location.href = '/roundtheboard/index'
        )
        .catch(error => console.error('Error:', error));
}

// create a function named handlethrow that has a parameter of the button
function setThrow(button) {
    // set the value of the hiden throwValue input to the value of the button
    document.getElementById('throwValue').value = button.value;

    // call the handleThrow function
    handleThrow();
}