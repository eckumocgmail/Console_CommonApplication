function ResourceFactory( pelement ){

			console.log(pelement.id,'ResourceFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


}


