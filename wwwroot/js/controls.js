

/******************************************************************
 *   Возвращает набор ресурсов распростаняемых службами ВЕБАПИ
 ***************************************************************/
var web = {};
function WebAPI()
{
    angular.forEach(document.querySelectorAll('[ng-controller]'),( ctrl) => {
        web[ctrl.getAttribute('ng-controller')] = ctrl;
    });
    return web;
}
window.addEventListener('load', () => { web=WebAPI();})








/**************************************************************************
    <!-- меню -->
    <div id="menu1"
         style="z-index: 1; display: none; padding: 5px; margin: 5px;"
         onmouseleave="$context.close(this)">
        <ul class="list-group">
            <h6> меню </h6>
            <li class="list-group-item" onmouseover="this.classList.add('active')" onmouseleave="this.classList.remove('active')"> открыть </li>
            <li class="list-group-item" onmouseover="this.classList.add('active')" onmouseleave="this.classList.remove('active')"> свойства </li>
        </ul>
    </div>


    <!-- область конектного меню -->
    <div style="width: 100%; height: 200px;"
         onclick="$context.open(menu1)">
        test
    </div>
 **/
const $context = {

    open(id) {
        
        const element = document.getElementById(id);
        if (event && event.preventDefault)
            event.preventDefault();

        const all = document.querySelectorAll('.view-component-menu');
        for (let i = 0; i < all.length; i++) {
            //all[i].style.display = 'none';
            all[i].setAttribute('hidden', 'true');
        }
        if (!element) {
            alert('Элемент контекстного меню не задан');
        } else {
            if (!event) {
                event = {
                    clientX: 100,
                    clientY: 100
                }
            }
            element.style.position = 'fixed';
            element.style.display = 'block';
            element.style.left = (event.clientX - 25) + 'px';
            element.style.top = (event.clientY - 25) + 'px';
            element.removeAttribute('hidden');

        }
    },

    close(element) {
        element.style.display = 'none';
        const all = document.querySelectorAll('.view-component-menu');
        for (let i = 0; i < all.length; i++) {
            all[i].style.display = 'none';
        }
    }
}


function toggleFullScreen() {
    if (!document.fullscreenElement &&    // alternative standard method
        !document.mozFullScreenElement && !document.webkitFullscreenElement && !document.msFullscreenElement) {  // current working methods
        if (document.documentElement.requestFullscreen) {
            document.documentElement.requestFullscreen();
        } else if (document.documentElement.msRequestFullscreen) {
            document.documentElement.msRequestFullscreen();
        } else if (document.documentElement.mozRequestFullScreen) {
            document.documentElement.mozRequestFullScreen();
        } else if (document.documentElement.webkitRequestFullscreen) {
            document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT);
        }
    } else {
        if (document.exitFullscreen) {
            document.exitFullscreen();
        } else if (document.msExitFullscreen) {
            document.msExitFullscreen();
        } else if (document.mozCancelFullScreen) {
            document.mozCancelFullScreen();
        } else if (document.webkitExitFullscreen) {
            document.webkitExitFullscreen();
        }
    }
}