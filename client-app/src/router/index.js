import VueRouter from "vue-router";

const routes = [
    {
        path: '/',
        redirect: '/login'
    },
    {
        path: '/login',
        component: () => import("../pages/login/Login"),
    },
    {
        path: '/tests',
        component: () => import("../pages/tests/ListTests"),
    },
    {
        path: '/tests/:id',
        component: () => import("../pages/tests/TestPage"),
    }
]

const router = new VueRouter({
    mode: 'history',
    routes
})

export default router;