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

function toggleBullsEye() {
    // if the multiple buttons are disabled, enable them
    if (document.querySelector('.multiplier').disabled) {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = false);
        document.getElementById('throwValue').disabled = false;
        document.getElementById('outerBullThrow').disabled = false;
        return;
    }
    else {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = true);
        document.getElementById('throwValue').disabled = true;
        document.getElementById('outerBullThrow').disabled = true;
    }
}

function toggleOuterBull() {
    // if the multiple buttons are disabled, enable them
    if (document.querySelector('.multiplier').disabled) {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = false);
        document.getElementById('throwValue').disabled = false;
        document.getElementById('bullseyeThrow').disabled = false;
        return;
    }
    else {
        document.querySelectorAll('.multiplier').forEach(button => button.disabled = true);
        document.getElementById('throwValue').disabled = true;
        document.getElementById('bullseyeThrow').disabled = true;
    }
}

