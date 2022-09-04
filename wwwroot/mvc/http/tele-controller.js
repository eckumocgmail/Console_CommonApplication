function TeleFactory( pelement ){

			console.log(pelement.id,'TeleFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


			this.ngOnInit=function(  ){
				let pars = toHttpParams({

				} );
				console.log('ngOnInit', pars);
 				return window['https']({ url: '/Tele/ngOnInit', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.ngOnDestroy=function(  ){
				let pars = toHttpParams({

				} );
				console.log('ngOnDestroy', pars);
 				return window['https']({ url: '/Tele/ngOnDestroy', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.ngOnChanges=function( changes ){
				let pars = toHttpParams({
				changes: changes
				} );
				console.log('ngOnChanges', pars);
 				return window['https']({ url: '/Tele/ngOnChanges', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.view=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('view', pars);
 				return window['https']({ url: '/Tele/View', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getSettings=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getSettings', pars);
 				return window['https']({ url: '/Tele/GetSettings', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.setup=function(  ){
				let pars = toHttpParams({

				} );
				console.log('setup', pars);
 				return window['https']({ url: '/Tele/Setup', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.infoDialog=function( Title,Text,Button ){
				let pars = toHttpParams({
				Title: Title,
				Text: Text,
				Button: Button
				} );
				console.log('infoDialog', pars);
 				return window['https']({ url: '/Tele/InfoDialog', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.showHelp=function( Text ){
				let pars = toHttpParams({
				Text: Text
				} );
				console.log('showHelp', pars);
 				return window['https']({ url: '/Tele/ShowHelp', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.remoteDialog=function( Title,Url ){
				let pars = toHttpParams({
				Title: Title,
				Url: Url
				} );
				console.log('remoteDialog', pars);
 				return window['https']({ url: '/Tele/RemoteDialog', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.confirmDialog=function( Title,Text ){
				let pars = toHttpParams({
				Title: Title,
				Text: Text
				} );
				console.log('confirmDialog', pars);
 				return window['https']({ url: '/Tele/ConfirmDialog', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createEntityDialog=function( Title,Entity ){
				let pars = toHttpParams({
				Title: Title,
				Entity: Entity
				} );
				console.log('createEntityDialog', pars);
 				return window['https']({ url: '/Tele/CreateEntityDialog', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.inputDialog=function( Title,Properties ){
				let pars = toHttpParams({
				Title: Title,
				Properties: Properties
				} );
				console.log('inputDialog', pars);
 				return window['https']({ url: '/Tele/InputDialog', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.eval=function( js ){
				let pars = toHttpParams({
				js: js
				} );
				console.log('eval', pars);
 				return window['https']({ url: '/Tele/Eval', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.handleEvalResult=function( handle,js ){
				let pars = toHttpParams({
				handle: handle,
				js: js
				} );
				console.log('handleEvalResult', pars);
 				return window['https']({ url: '/Tele/HandleEvalResult', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.callback=function( action,args ){
				let pars = toHttpParams({
				action: action,
				args: args
				} );
				console.log('callback', pars);
 				return window['https']({ url: '/Tele/Callback', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.addEventListener=function( id,type,js ){
				let pars = toHttpParams({
				id: id,
				type: type,
				js: js
				} );
				console.log('addEventListener', pars);
 				return window['https']({ url: '/Tele/AddEventListener', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.dispatchEvent=function( id,type,message ){
				let pars = toHttpParams({
				id: id,
				type: type,
				message: message
				} );
				console.log('dispatchEvent', pars);
 				return window['https']({ url: '/Tele/DispatchEvent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onConnected=function( token ){
				let pars = toHttpParams({
				token: token
				} );
				console.log('onConnected', pars);
 				return window['https']({ url: '/Tele/OnConnected', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.partialView=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('partialView', pars);
 				return window['https']({ url: '/Tele/PartialView', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.viewComponent=function( componentType,arguments ){
				let pars = toHttpParams({
				componentType: componentType,
				arguments: arguments
				} );
				console.log('viewComponent', pars);
 				return window['https']({ url: '/Tele/ViewComponent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.json=function( data,serializerSettings ){
				let pars = toHttpParams({
				data: data,
				serializerSettings: serializerSettings
				} );
				console.log('json', pars);
 				return window['https']({ url: '/Tele/Json', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuting=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuting', pars);
 				return window['https']({ url: '/Tele/OnActionExecuting', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuted=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuted', pars);
 				return window['https']({ url: '/Tele/OnActionExecuted', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecutionAsync=function( context,next ){
				let pars = toHttpParams({
				context: context,
				next: next
				} );
				console.log('onActionExecutionAsync', pars);
 				return window['https']({ url: '/Tele/OnActionExecutionAsync', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.dispose=function(  ){
				let pars = toHttpParams({

				} );
				console.log('dispose', pars);
 				return window['https']({ url: '/Tele/Dispose', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.conflict=function( error ){
				let pars = toHttpParams({
				error: error
				} );
				console.log('conflict', pars);
 				return window['https']({ url: '/Tele/Conflict', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Tele/Problem', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Tele/ValidationProblem', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.created=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('created', pars);
 				return window['https']({ url: '/Tele/Created', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtAction', pars);
 				return window['https']({ url: '/Tele/CreatedAtAction', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtRoute', pars);
 				return window['https']({ url: '/Tele/CreatedAtRoute', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.accepted=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('accepted', pars);
 				return window['https']({ url: '/Tele/Accepted', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtAction', pars);
 				return window['https']({ url: '/Tele/AcceptedAtAction', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtRoute', pars);
 				return window['https']({ url: '/Tele/AcceptedAtRoute', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.challenge=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('challenge', pars);
 				return window['https']({ url: '/Tele/Challenge', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.forbid=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('forbid', pars);
 				return window['https']({ url: '/Tele/Forbid', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signIn=function( principal,properties,authenticationScheme ){
				let pars = toHttpParams({
				principal: principal,
				properties: properties,
				authenticationScheme: authenticationScheme
				} );
				console.log('signIn', pars);
 				return window['https']({ url: '/Tele/SignIn', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signOut=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('signOut', pars);
 				return window['https']({ url: '/Tele/SignOut', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Tele/TryUpdateModelAsync', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.tryValidateModel=function( model,prefix ){
				let pars = toHttpParams({
				model: model,
				prefix: prefix
				} );
				console.log('tryValidateModel', pars);
 				return window['https']({ url: '/Tele/TryValidateModel', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.statusCode=function( statusCode,value ){
				let pars = toHttpParams({
				statusCode: statusCode,
				value: value
				} );
				console.log('statusCode', pars);
 				return window['https']({ url: '/Tele/StatusCode', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.content=function( content,contentType ){
				let pars = toHttpParams({
				content: content,
				contentType: contentType
				} );
				console.log('content', pars);
 				return window['https']({ url: '/Tele/Content', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.noContent=function(  ){
				let pars = toHttpParams({

				} );
				console.log('noContent', pars);
 				return window['https']({ url: '/Tele/NoContent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.ok=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('ok', pars);
 				return window['https']({ url: '/Tele/Ok', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirect=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirect', pars);
 				return window['https']({ url: '/Tele/Redirect', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanent=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanent', pars);
 				return window['https']({ url: '/Tele/RedirectPermanent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanentPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectPermanentPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirect=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirect', pars);
 				return window['https']({ url: '/Tele/LocalRedirect', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanent=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanent', pars);
 				return window['https']({ url: '/Tele/LocalRedirectPermanent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPreserveMethod', pars);
 				return window['https']({ url: '/Tele/LocalRedirectPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanentPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Tele/LocalRedirectPermanentPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToAction=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToAction', pars);
 				return window['https']({ url: '/Tele/RedirectToAction', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToActionPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanent=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanent', pars);
 				return window['https']({ url: '/Tele/RedirectToActionPermanent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanentPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToActionPermanentPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoute=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoute', pars);
 				return window['https']({ url: '/Tele/RedirectToRoute', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToRoutePreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanent=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanent', pars);
 				return window['https']({ url: '/Tele/RedirectToRoutePermanent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanentPreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanentPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToRoutePermanentPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPage=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPage', pars);
 				return window['https']({ url: '/Tele/RedirectToPage', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanent=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanent', pars);
 				return window['https']({ url: '/Tele/RedirectToPagePermanent', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToPagePreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanentPreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanentPreserveMethod', pars);
 				return window['https']({ url: '/Tele/RedirectToPagePermanentPreserveMethod', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Tele/File', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Tele/PhysicalFile', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unauthorized=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('unauthorized', pars);
 				return window['https']({ url: '/Tele/Unauthorized', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.notFound=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('notFound', pars);
 				return window['https']({ url: '/Tele/NotFound', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.badRequest=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('badRequest', pars);
 				return window['https']({ url: '/Tele/BadRequest', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unprocessableEntity=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('unprocessableEntity', pars);
 				return window['https']({ url: '/Tele/UnprocessableEntity', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getType=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getType', pars);
 				return window['https']({ url: '/Tele/GetType', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.toString=function(  ){
				let pars = toHttpParams({

				} );
				console.log('toString', pars);
 				return window['https']({ url: '/Tele/ToString', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.equals=function( obj ){
				let pars = toHttpParams({
				obj: obj
				} );
				console.log('equals', pars);
 				return window['https']({ url: '/Tele/Equals', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getHashCode=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getHashCode', pars);
 				return window['https']({ url: '/Tele/GetHashCode', type: 'TeleFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


}


