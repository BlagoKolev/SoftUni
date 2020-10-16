function solve(){

    const proto = {};
    const instance = Object.create(proto);

    instance.extend = function(template){

         for (const key in template) {
             if (typeof template[key] === 'function') {
               proto[key] = template[key];
                 
             } else{
                instance[key] = template[key];
             }
         }
    }

    return instance;
}
const myInstance = solve();
myInstance.extend({
    extensionMethod: function () {},
    extensionProperty: 'someString'
  
})
console.log(myInstance)
console.log(Object.getPrototypeOf(myInstance))