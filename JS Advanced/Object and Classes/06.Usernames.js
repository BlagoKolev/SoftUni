function solve(input){

    let usernames = new Set();
    input.forEach(element => {
        usernames.add(element);
    });
    usernames = Array.from(usernames).sort((a,b) => a.length - b.length || a.localeCompare(b));
    console.log(usernames);
}

solve(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot']

)