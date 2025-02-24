﻿function addPlayer() {
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

function toggleBullsEye() {
    // if the multiple buttons are disabled, enable them
    if (document.querySelector('.multiplier').disabled) {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = false);
        document.getElementById('throwValue').disabled = false;
        document.getElementById('outerBullThrow').disabled = false;
        document.getElementById('bullseyeThrow').classList.remove('bullseye');
        return;
    }
    else {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = true);
        document.getElementById('throwValue').disabled = true;
        document.getElementById('outerBullThrow').disabled = true;
        document.getElementById('bullseyeThrow').classList.add('bullseye');
    }
}

function toggleOuterBull() {
    // if the multiple buttons are disabled, enable them
    if (document.querySelector('.multiplier').disabled) {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = false);
        document.getElementById('throwValue').disabled = false;
        document.getElementById('bullseyeThrow').disabled = false;
        document.getElementById('outerBullThrow').classList.remove('outerbull');
        return;
    }
    else {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = true);
        document.getElementById('throwValue').disabled = true;
        document.getElementById('bullseyeThrow').disabled = true;
        document.getElementById('outerBullThrow').classList.add('outerbull');
    }
}

function toggleMultiplier(button) {
    switch (button.id) {
        case 'double':
            document.getElementById('treble').disabled = !ocument.getElementById('treble').disabled;
            break;
        case 'treble':
            document.getElementById('double').disabled = !document.getElementById('double').disabled;
            break;
    }
}

function handleThrow()
{
    var multiplier = 'S';
    if (document.getElementById('treble').enabled && document.getElementById('double').disabled) {
        multiplier = 'T';
    }
    else if (document.getElementById('double').enabled && document.getElementById('treble').disabled) {
        multiplier = 'D';
    }
    
    var throwValue = document.getElementById('throwValue').value;

    fetch('/RoundTheBoard/Throw', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ multiplier: multiplier, throwValue: throwValue })
    })
        .then(response => // redierct to the home page
            window.location.href = '/roundtheboard/index'
        )
        .catch(error => console.error('Error:', error));
}