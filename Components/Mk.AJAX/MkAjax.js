var MkAjax = function() {
    var t = [],
        blockingCallsNumber = 0,
        n = 0,
        blockingCa = function() {
            blockingCallsNumber++;
        },
        r = function() {
            blockingCallsNumber--, 0 > blockingCallsNumber && (blockingCallsNumber = 0);
        },
        u = function() {
            n++;
        },
        a = function() {
            n--, 0 > n && (n = 0);
        },
        s = function() {
            return n + blockingCallsNumber;
        },
        callAsync = function(e, n, o, r) {
            var u = d(e, n, o, r);
            t.push(u), l();
        },
        callBlock = function(t, e, n) {
            blockingCa();
            var u = d(t, e, n, null);
            try {
                var a = p(u);
                return r(), a;
            } catch (s) {
                throw r(), s;
            }
        },
        l = function() {
            t.length && setTimeout(function() {
                f();
            }, 50);
        },
        f = function() {
            var n = null;
            return 0 == s() ? (n = t.shift(), n && T(n), void l()) : 1 == s() ? (0 != blockingCallsNumber && (n = t.shift(), n && T(n)), void l()) : void l();
        },
        d = function(t, e, n, o) {
            var r = function(t) {
                var e = [];
                for (var n in t) {
                    var o = t[n],
                        r = typeof o;
                    null == o || "object" != r && o.constructor != Array || (o = JSON.stringify(o)), e.push(n + "=" + escape(o));
                }
                return e.join("&");
            };
            return {
                URL: t + (e ? "" : "?" + r(n)),
                isPost: e,
                body: e ? r(n) : null,
                callback: o
            };
        },
        v = function() {
            return window.XMLHttpRequest ? new XMLHttpRequest : window.ActiveXObject ? new ActiveXObject("Microsoft.XMLHTTP") : null;
        },
        p = function(t) {
            var e = v();
            e.open(t.isPost ? "POST" : "GET", t.URL, !1), e.setRequestHeader("RequestTarget", "MethodCall"), e.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"), e.send(t.isPost && t.body ? t.body : null);
            var n = e.status;
            if (200 != n && 304 != n) throw e.responseText;
            return e.responseText;
        },
        T = function(t) {
            var e = v();
            e.open(t.isPost ? "POST" : "GET", t.URL, !0), e.setRequestHeader("RequestTarget", "MethodCall"), e.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            var n = setTimeout(function() {
                n = 0, a();
            }, 6e4);
            e.onreadystatechange = function() {
                if (4 == e.readyState) {
                    a(), l(), n && clearTimeout(n);
                    var o = 200 == e.status || 304 == e.status;
                    t.callback && t.callback(o, e.responseText);
                }
            }, u(), e.send(t.isPost && t.body ? t.body : null);
        };
    return {
        callAsync: callAsync,
        callBlock: callBlock
    };
}();