function solve(input) {
    let container = {};
    for (let i = 0; i < arguments.length; i++) {
        let type = typeof arguments[i];
        if (!container.hasOwnProperty(type)) {
            container[type] = 0;
        }
        container[type]++;

        console.log(`${type}: ${arguments[i]}`)
    }
    Object.keys(container).sort((a, b) => container[b] - container[a]).forEach(x => console.log(`${x} = ${container[x]}`));
    for (const key in container) {
        console.log(key)

    }
}
    


solve('cat', 'dog', 'fog', 42, 5, 6, 7, function () { console.log('Hello world!'); }
)