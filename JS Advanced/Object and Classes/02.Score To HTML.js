function solve(input) {

    const parsedInput = JSON.parse(input);
    let table = '<table>\n<tr><th>name</th><th>score</th></tr>';

    for (const obj of parsedInput) {
        obj.name = escapeHTML(obj.name);
        table = table.concat(`\n<tr><td>${obj.name}</td><td>${obj.score}</td></tr>`);
    }
    table = table.concat('\n</table>');

    console.log(table)

    function escapeHTML(unsafeString) {
        return unsafeString.replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }
}

solve([`[{"name":"Pesho & a","score":479},
{"name":"Gosho","score":205}]`])