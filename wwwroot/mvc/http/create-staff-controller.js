function CreateStaffFactory( pelement ){

			console.log(pelement.id,'CreateStaffFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


			this.get=function(  ){
				let pars = toHttpParams({

				} );
				console.log('get', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Get', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.post=function( model ){
				let pars = toHttpParams({
				model: model
				} );
				console.log('post', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Post', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.index=function(  ){
				let pars = toHttpParams({

				} );
				console.log('index', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Index', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.actionLink=function( action ){
				let pars = toHttpParams({
				action: action
				} );
				console.log('actionLink', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ActionLink', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.view=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('view', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/View', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getSettings=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getSettings', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/GetSettings', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.setup=function(  ){
				let pars = toHttpParams({

				} );
				console.log('setup', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Setup', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.infoDialog=function( Title,Text,Button ){
				let pars = toHttpParams({
				Title: Title,
				Text: Text,
				Button: Button
				} );
				console.log('infoDialog', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/InfoDialog', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.showHelp=function( Text ){
				let pars = toHttpParams({
				Text: Text
				} );
				console.log('showHelp', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ShowHelp', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.remoteDialog=function( Title,Url ){
				let pars = toHttpParams({
				Title: Title,
				Url: Url
				} );
				console.log('remoteDialog', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RemoteDialog', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.confirmDialog=function( Title,Text ){
				let pars = toHttpParams({
				Title: Title,
				Text: Text
				} );
				console.log('confirmDialog', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ConfirmDialog', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createEntityDialog=function( Title,Entity ){
				let pars = toHttpParams({
				Title: Title,
				Entity: Entity
				} );
				console.log('createEntityDialog', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/CreateEntityDialog', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.inputDialog=function( Title,Properties ){
				let pars = toHttpParams({
				Title: Title,
				Properties: Properties
				} );
				console.log('inputDialog', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/InputDialog', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.eval=function( js ){
				let pars = toHttpParams({
				js: js
				} );
				console.log('eval', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Eval', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.handleEvalResult=function( handle,js ){
				let pars = toHttpParams({
				handle: handle,
				js: js
				} );
				console.log('handleEvalResult', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/HandleEvalResult', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.callback=function( action,args ){
				let pars = toHttpParams({
				action: action,
				args: args
				} );
				console.log('callback', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Callback', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.addEventListener=function( id,type,js ){
				let pars = toHttpParams({
				id: id,
				type: type,
				js: js
				} );
				console.log('addEventListener', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/AddEventListener', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.dispatchEvent=function( id,type,message ){
				let pars = toHttpParams({
				id: id,
				type: type,
				message: message
				} );
				console.log('dispatchEvent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/DispatchEvent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onConnected=function( token ){
				let pars = toHttpParams({
				token: token
				} );
				console.log('onConnected', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/OnConnected', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.info=function( message ){
				let pars = toHttpParams({
				message: message
				} );
				console.log('info', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Info', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.error=function( ex ){
				let pars = toHttpParams({
				ex: ex
				} );
				console.log('error', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Error', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.partialView=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('partialView', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/PartialView', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.viewComponent=function( componentType,arguments ){
				let pars = toHttpParams({
				componentType: componentType,
				arguments: arguments
				} );
				console.log('viewComponent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ViewComponent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.json=function( data,serializerSettings ){
				let pars = toHttpParams({
				data: data,
				serializerSettings: serializerSettings
				} );
				console.log('json', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Json', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuting=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuting', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/OnActionExecuting', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuted=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuted', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/OnActionExecuted', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecutionAsync=function( context,next ){
				let pars = toHttpParams({
				context: context,
				next: next
				} );
				console.log('onActionExecutionAsync', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/OnActionExecutionAsync', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.dispose=function(  ){
				let pars = toHttpParams({

				} );
				console.log('dispose', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Dispose', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.conflict=function( error ){
				let pars = toHttpParams({
				error: error
				} );
				console.log('conflict', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Conflict', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.problem=function( detail,instance,statusCode,title,type ){
				let pars = toHttpParams({
				detail: detail,
				instance: instance,
				statusCode: statusCode,
				title: title,
				type: type
				} );
				console.log('problem', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Problem', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.validationProblem=function( detail,instance,statusCode,title,type,modelStateDictionary ){
				let pars = toHttpParams({
				detail: detail,
				instance: instance,
				statusCode: statusCode,
				title: title,
				type: type,
				modelStateDictionary: modelStateDictionary
				} );
				console.log('validationProblem', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ValidationProblem', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.created=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('created', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Created', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtAction', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/CreatedAtAction', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtRoute', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/CreatedAtRoute', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.accepted=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('accepted', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Accepted', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtAction', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/AcceptedAtAction', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtRoute', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/AcceptedAtRoute', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.challenge=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('challenge', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Challenge', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.forbid=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('forbid', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Forbid', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signIn=function( principal,properties,authenticationScheme ){
				let pars = toHttpParams({
				principal: principal,
				properties: properties,
				authenticationScheme: authenticationScheme
				} );
				console.log('signIn', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/SignIn', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signOut=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('signOut', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/SignOut', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.tryUpdateModelAsync=function( model,modelType,prefix,valueProvider,propertyFilter ){
				let pars = toHttpParams({
				model: model,
				modelType: modelType,
				prefix: prefix,
				valueProvider: valueProvider,
				propertyFilter: propertyFilter
				} );
				console.log('tryUpdateModelAsync', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/TryUpdateModelAsync', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.tryValidateModel=function( model,prefix ){
				let pars = toHttpParams({
				model: model,
				prefix: prefix
				} );
				console.log('tryValidateModel', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/TryValidateModel', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.statusCode=function( statusCode,value ){
				let pars = toHttpParams({
				statusCode: statusCode,
				value: value
				} );
				console.log('statusCode', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/StatusCode', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.content=function( content,contentType ){
				let pars = toHttpParams({
				content: content,
				contentType: contentType
				} );
				console.log('content', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Content', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.noContent=function(  ){
				let pars = toHttpParams({

				} );
				console.log('noContent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/NoContent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.ok=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('ok', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Ok', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirect=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirect', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Redirect', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanent=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectPermanent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanentPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectPermanentPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirect=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirect', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/LocalRedirect', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanent=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/LocalRedirectPermanent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/LocalRedirectPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanentPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/LocalRedirectPermanentPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToAction=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToAction', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToAction', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToActionPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanent=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToActionPermanent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanentPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanentPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToActionPermanentPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoute=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoute', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToRoute', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToRoutePreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanent=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToRoutePermanent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanentPreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanentPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToRoutePermanentPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPage=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPage', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToPage', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanent=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanent', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToPagePermanent', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToPagePreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanentPreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanentPreserveMethod', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/RedirectToPagePermanentPreserveMethod', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.file=function( virtualPath,contentType,fileDownloadName,lastModified,entityTag,enableRangeProcessing ){
				let pars = toHttpParams({
				virtualPath: virtualPath,
				contentType: contentType,
				fileDownloadName: fileDownloadName,
				lastModified: lastModified,
				entityTag: entityTag,
				enableRangeProcessing: enableRangeProcessing
				} );
				console.log('file', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/File', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.physicalFile=function( physicalPath,contentType,fileDownloadName,lastModified,entityTag,enableRangeProcessing ){
				let pars = toHttpParams({
				physicalPath: physicalPath,
				contentType: contentType,
				fileDownloadName: fileDownloadName,
				lastModified: lastModified,
				entityTag: entityTag,
				enableRangeProcessing: enableRangeProcessing
				} );
				console.log('physicalFile', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/PhysicalFile', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unauthorized=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('unauthorized', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Unauthorized', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.notFound=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('notFound', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/NotFound', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.badRequest=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('badRequest', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/BadRequest', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unprocessableEntity=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('unprocessableEntity', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/UnprocessableEntity', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.equals=function( obj ){
				let pars = toHttpParams({
				obj: obj
				} );
				console.log('equals', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/Equals', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getHashCode=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getHashCode', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/GetHashCode', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getType=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getType', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/GetType', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.toString=function(  ){
				let pars = toHttpParams({

				} );
				console.log('toString', pars);
 				return window['https']({ url: '/AdminFace/CreateStaff/ToString', type: 'CreateStaffFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


}


