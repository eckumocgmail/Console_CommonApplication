function RoutingFactory( pelement ){

			console.log(pelement.id,'RoutingFactory');



			function toHttpParams(obj)
			{ 
			     let result = { }; 
			     Object.getOwnPropertyNames(obj).forEach(name => { 
			         result[name] = window['convertToHttpMessageParam'](obj[name]); 
			     }); 
			     return result; 
			}           


			this.view=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('view', pars);
 				return window['https']({ url: '/Routing/View', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.partialView=function( viewName,model ){
				let pars = toHttpParams({
				viewName: viewName,
				model: model
				} );
				console.log('partialView', pars);
 				return window['https']({ url: '/Routing/PartialView', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.viewComponent=function( componentType,arguments ){
				let pars = toHttpParams({
				componentType: componentType,
				arguments: arguments
				} );
				console.log('viewComponent', pars);
 				return window['https']({ url: '/Routing/ViewComponent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.json=function( data,serializerSettings ){
				let pars = toHttpParams({
				data: data,
				serializerSettings: serializerSettings
				} );
				console.log('json', pars);
 				return window['https']({ url: '/Routing/Json', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuting=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuting', pars);
 				return window['https']({ url: '/Routing/OnActionExecuting', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecuted=function( context ){
				let pars = toHttpParams({
				context: context
				} );
				console.log('onActionExecuted', pars);
 				return window['https']({ url: '/Routing/OnActionExecuted', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.onActionExecutionAsync=function( context,next ){
				let pars = toHttpParams({
				context: context,
				next: next
				} );
				console.log('onActionExecutionAsync', pars);
 				return window['https']({ url: '/Routing/OnActionExecutionAsync', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.dispose=function(  ){
				let pars = toHttpParams({

				} );
				console.log('dispose', pars);
 				return window['https']({ url: '/Routing/Dispose', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.conflict=function( error ){
				let pars = toHttpParams({
				error: error
				} );
				console.log('conflict', pars);
 				return window['https']({ url: '/Routing/Conflict', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Routing/Problem', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Routing/ValidationProblem', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.created=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('created', pars);
 				return window['https']({ url: '/Routing/Created', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtAction', pars);
 				return window['https']({ url: '/Routing/CreatedAtAction', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.createdAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('createdAtRoute', pars);
 				return window['https']({ url: '/Routing/CreatedAtRoute', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.accepted=function( uri,value ){
				let pars = toHttpParams({
				uri: uri,
				value: value
				} );
				console.log('accepted', pars);
 				return window['https']({ url: '/Routing/Accepted', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtAction=function( actionName,controllerName,routeValues,value ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtAction', pars);
 				return window['https']({ url: '/Routing/AcceptedAtAction', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.acceptedAtRoute=function( routeName,routeValues,value ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				value: value
				} );
				console.log('acceptedAtRoute', pars);
 				return window['https']({ url: '/Routing/AcceptedAtRoute', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.challenge=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('challenge', pars);
 				return window['https']({ url: '/Routing/Challenge', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.forbid=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('forbid', pars);
 				return window['https']({ url: '/Routing/Forbid', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signIn=function( principal,properties,authenticationScheme ){
				let pars = toHttpParams({
				principal: principal,
				properties: properties,
				authenticationScheme: authenticationScheme
				} );
				console.log('signIn', pars);
 				return window['https']({ url: '/Routing/SignIn', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.signOut=function( properties,authenticationSchemes ){
				let pars = toHttpParams({
				properties: properties,
				authenticationSchemes: authenticationSchemes
				} );
				console.log('signOut', pars);
 				return window['https']({ url: '/Routing/SignOut', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Routing/TryUpdateModelAsync', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.tryValidateModel=function( model,prefix ){
				let pars = toHttpParams({
				model: model,
				prefix: prefix
				} );
				console.log('tryValidateModel', pars);
 				return window['https']({ url: '/Routing/TryValidateModel', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.statusCode=function( statusCode,value ){
				let pars = toHttpParams({
				statusCode: statusCode,
				value: value
				} );
				console.log('statusCode', pars);
 				return window['https']({ url: '/Routing/StatusCode', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.content=function( content,contentType ){
				let pars = toHttpParams({
				content: content,
				contentType: contentType
				} );
				console.log('content', pars);
 				return window['https']({ url: '/Routing/Content', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.noContent=function(  ){
				let pars = toHttpParams({

				} );
				console.log('noContent', pars);
 				return window['https']({ url: '/Routing/NoContent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.ok=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('ok', pars);
 				return window['https']({ url: '/Routing/Ok', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirect=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirect', pars);
 				return window['https']({ url: '/Routing/Redirect', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanent=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanent', pars);
 				return window['https']({ url: '/Routing/RedirectPermanent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectPermanentPreserveMethod=function( url ){
				let pars = toHttpParams({
				url: url
				} );
				console.log('redirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectPermanentPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirect=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirect', pars);
 				return window['https']({ url: '/Routing/LocalRedirect', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanent=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanent', pars);
 				return window['https']({ url: '/Routing/LocalRedirectPermanent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPreserveMethod', pars);
 				return window['https']({ url: '/Routing/LocalRedirectPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.localRedirectPermanentPreserveMethod=function( localUrl ){
				let pars = toHttpParams({
				localUrl: localUrl
				} );
				console.log('localRedirectPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Routing/LocalRedirectPermanentPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToAction=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToAction', pars);
 				return window['https']({ url: '/Routing/RedirectToAction', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToActionPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanent=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanent', pars);
 				return window['https']({ url: '/Routing/RedirectToActionPermanent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToActionPermanentPreserveMethod=function( actionName,controllerName,routeValues,fragment ){
				let pars = toHttpParams({
				actionName: actionName,
				controllerName: controllerName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToActionPermanentPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToActionPermanentPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoute=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoute', pars);
 				return window['https']({ url: '/Routing/RedirectToRoute', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToRoutePreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanent=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanent', pars);
 				return window['https']({ url: '/Routing/RedirectToRoutePermanent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToRoutePermanentPreserveMethod=function( routeName,routeValues,fragment ){
				let pars = toHttpParams({
				routeName: routeName,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToRoutePermanentPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToRoutePermanentPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPage=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPage', pars);
 				return window['https']({ url: '/Routing/RedirectToPage', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanent=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanent', pars);
 				return window['https']({ url: '/Routing/RedirectToPagePermanent', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToPagePreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.redirectToPagePermanentPreserveMethod=function( pageName,pageHandler,routeValues,fragment ){
				let pars = toHttpParams({
				pageName: pageName,
				pageHandler: pageHandler,
				routeValues: routeValues,
				fragment: fragment
				} );
				console.log('redirectToPagePermanentPreserveMethod', pars);
 				return window['https']({ url: '/Routing/RedirectToPagePermanentPreserveMethod', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Routing/File', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
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
 				return window['https']({ url: '/Routing/PhysicalFile', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unauthorized=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('unauthorized', pars);
 				return window['https']({ url: '/Routing/Unauthorized', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.notFound=function( value ){
				let pars = toHttpParams({
				value: value
				} );
				console.log('notFound', pars);
 				return window['https']({ url: '/Routing/NotFound', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.badRequest=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('badRequest', pars);
 				return window['https']({ url: '/Routing/BadRequest', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.unprocessableEntity=function( modelState ){
				let pars = toHttpParams({
				modelState: modelState
				} );
				console.log('unprocessableEntity', pars);
 				return window['https']({ url: '/Routing/UnprocessableEntity', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getType=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getType', pars);
 				return window['https']({ url: '/Routing/GetType', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.toString=function(  ){
				let pars = toHttpParams({

				} );
				console.log('toString', pars);
 				return window['https']({ url: '/Routing/ToString', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.equals=function( obj ){
				let pars = toHttpParams({
				obj: obj
				} );
				console.log('equals', pars);
 				return window['https']({ url: '/Routing/Equals', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


			this.getHashCode=function(  ){
				let pars = toHttpParams({

				} );
				console.log('getHashCode', pars);
 				return window['https']({ url: '/Routing/GetHashCode', type: 'RoutingFactory', params: pars, headers: { 'Content-Type': 'text/json', Scope: pelement.id, Model: pelement?pelement.id.replace('view-',''): '' }, method: 'GET',}).then((r)=>{ window['checkout'](); return r; });
			}


}


