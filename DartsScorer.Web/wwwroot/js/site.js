function addPlayer() {
    alert("Player added");
}

//- add a new method Calculator Delete player
function deletePlayer(name) {

    if (confirm("Are you sure you want to delete " + name + "?")) {
        fetch('/Player/DeletePlayer', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Name: name })
        })
        .then(response => // redierct to the home page
            window.location.href = '/player/index'
        )
        .catch(error => console.error('Error:', error));
    }
}

//- add a new method Calculator updatePlayerName
function updatePlayerName(oldName, newName) {
    fetch('/Player/EditPlayer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ OldName: oldName, Name: newName })
    })
    .then(response => // redierct to the home page
        window.location.href = '/player/index'
    )
    .catch(error => console.error('Error:', error));
}

function clickDouble(button)
{
    document.getElementById('treble').disabled = !document.getElementById('treble').disabled;
    document.getElementById('bullseyeThrow').disabled = !document.getElementById('bullseyeThrow').disabled;
    document.getElementById('outerBullThrow').disabled = !document.getElementById('outerBullThrow').disabled;
}

function clickTreble(button)
{
    document.getElementById('double').disabled = !document.getElementById('double').disabled;
    document.getElementById('bullseyeThrow').disabled = !document.getElementById('bullseyeThrow').disabled;
    document.getElementById('outerBullThrow').disabled = !document.getElementById('outerBullThrow').disabled;
}

function toggleMultiplier(button) {
    switch (button.id) {
        case 'double':
            document.getElementById('treble').disabled = !document.getElementById('treble').disabled;
            // toggle the bullseye button if the treble is enabled
            if (!document.getElementById('treble').disabled) {
                document.getElementById('bullseyeThrow').disabled = !document.getElementById('bullseyeThrow').disabled;
                document.getElementById('outerBullThrow').disabled = !document.getElementById('outerBullThrow').disabled;
            }
            break;
        case 'treble':
            document.getElementById('double').disabled = !document.getElementById('double').disabled;
            // toggle the bullseye button if the treble is enabled
            if (!document.getElementById('treble').disabled) {
                document.getElementById('bullseyeThrow').disabled = !document.getElementById('bullseyeThrow').disabled;
                document.getElementById('outerBullThrow').disabled = !document.getElementById('outerBullThrow').disabled;
            }
            break;
    }
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