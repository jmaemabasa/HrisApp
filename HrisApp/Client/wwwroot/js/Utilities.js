function my_function(message) {
    console.log("from utilities" + message);
}

function dotnetStaticInvocation() {
    DotNet.invokeMethodAsync("HrisApp.Client", "GetCurrentCount")
        .then(result => {
            console.log("count from javascript" + result)
        });
}

function dotnetInstanceInvocation(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}

function initializeInactivityTimer(dotnetHelper) {
    var timers;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timers);
        timers = setTimeout(logout, 300000);
    }

    function logout() {
        dotnetHelper.invokeMethodAsync("Logout");
    }
}