import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { ListRestaurants } from "./components/ListRestaurants";
import { Restaurant } from "./components/Restaurant";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
    {
        path: '/list-restaurants',
        element: <ListRestaurants />
    },
    {
        path: '/restaurant',
        element: <Restaurant />
    }
];

export default AppRoutes;
