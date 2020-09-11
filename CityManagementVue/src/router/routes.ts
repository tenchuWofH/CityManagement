import { RouteConfig } from 'vue-router';

// eslint-disable-next-line radix
// const parseProps = r => ({ cityId: parseInt(r.params.cityId) });

const routes: RouteConfig[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('pages/Index.vue') },
      { path: '/cities', component: () => import('pages/CityInfo.vue') },
    ],
  },
  // {
  //   path: '/cities',
  //   name: 'cities',
  //   component: () => import(/* webpackChunkName: "bundle.heroes" */ 'pages/CityList.vue'),
  // },
  // {
  //   path: '/cityEdit/:cityId',
  //   name: 'editCity',
  //   // props: true,
  //   props: parseProps,
  //   component: () => import(/* webpackChunkName: "bundle.heroes" */ 'pages/CityEdit.vue'),
  // },
];

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue'),
  });
}

export default routes;
