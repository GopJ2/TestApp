import VueRouter from "vue-router";
import auth from "../middlewares/auth";
const routes = [
    {
        path: '/',
        redirect: '/login'
    },
    {
        name: 'login',
        path: '/login',
        component: () => import("../pages/login/Login"),
    },
    {
        name: 'tests',
        path: '/tests',
        component: () => import("../pages/tests/ListTests"),
        meta: {middleware: auth}
    },
    {
        path: '/tests/:id',
        component: () => import("../pages/tests/TestPage"),
        meta: {middleware: auth}
    },
    {
        path: '/results/:id',
        component: () => import("../pages/tests/Results"),
        meta: {middleware: auth}
    }
];

const router = new VueRouter({
    mode: 'history',
    routes
})

function nextFactory(context, middleware, index) {
    const subsequentMiddleware = middleware[index];
        if (!subsequentMiddleware) return context.next;
        return (...parameters) => {
            context.next(...parameters);
            const nextMiddleware = nextFactory(context, middleware, index + 1);
            subsequentMiddleware({ ...context, next: nextMiddleware });
        };
    }

router.beforeEach((to, from, next) => {
    if (to.meta.middleware) {
        const middleware = Array.isArray(to.meta.middleware)
            ? to.meta.middleware
            : [to.meta.middleware];
        const context = {
            from,
            next,
            router,
            to,
        };
        const nextMiddleware = nextFactory(context, middleware, 1);
        return middleware[0]({ ...context, next: nextMiddleware });
    }

    return next()
});

export default router;