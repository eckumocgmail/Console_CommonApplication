function DashbordsFactory( pelement ){

			console.log(pelement.id,'DashbordsFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


			this.dragAndDropDashbord=function(  ){
				let pars = toHttpParams({

				} );
				console.log('dragAndDropDashbord', pars);
 				return window['https']({ url: '/DragAndDropDashbord', type: 'DashbordsFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.editableDashbord=function(  ){
				let pars = toHttpParams({

				} );
				console.log('editableDashbord', pars);
 				return window['https']({ url: '/EditableDashbord', type: 'DashbordsFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.nullableDashbord=function(  ){
				let pars = toHttpParams({

				} );
				console.log('nullableDashbord', pars);
 				return window['https']({ url: '/NullableDashbord', type: 'DashbordsFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.waterfailDashbord=function(  ){
				let pars = toHttpParams({

				} );
				console.log('waterfailDashbord', pars);
 				return window['https']({ url: '/WaterfailDashbord', type: 'DashbordsFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.view=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('view', pars);
 				return window['https']({ url: '/View', type: 'DashbordsFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


}


