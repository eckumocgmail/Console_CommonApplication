function UserServicesFactory( pelement ){

			console.log(pelement.id,'UserServicesFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


			this.userConnectedServices=function(  ){
				let pars = toHttpParams({

				} );
				console.log('userConnectedServices', pars);
 				return window['https']({ url: '/UserConnectedServices', type: 'UserServicesFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.userAccessibleServices=function(  ){
				let pars = toHttpParams({

				} );
				console.log('userAccessibleServices', pars);
 				return window['https']({ url: '/UserAccessibleServices', type: 'UserServicesFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.userActiveServices=function(  ){
				let pars = toHttpParams({

				} );
				console.log('userActiveServices', pars);
 				return window['https']({ url: '/UserActiveServices', type: 'UserServicesFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.view=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('view', pars);
 				return window['https']({ url: '/View', type: 'UserServicesFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


}


