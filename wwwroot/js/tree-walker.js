function $walkDown(action, pnode) {
    if (!pnode)
        pnode = document.body;
    action(pnode);
    if (pnode.childNodes) {
        for (let i = 0; i < pnode.childNodes.length; i++) {
            $walkDown(action, pnode.childNodes[i]);
        }
    }
}
function $broadcastEvent(evt, pnode) {
    const $fireEvent = function (p) {
        p.dispatchEvent(evt);
    };
    $walkDown($fireEvent, pnode);
}
