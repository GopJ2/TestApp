import VueRouter from "vue-router";

const routes = [
    {
        path: '/',
        component: () => import("../App"),
        redirect: '/login',
        children: [
            {
                path: 'login',
                component: () => import("../pages/login/Login"),
            }
        ]
    },
]

const router = new VueRouter({
    mode: 'history',
    routes
})

export default router;