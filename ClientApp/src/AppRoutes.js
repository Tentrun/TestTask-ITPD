import DashBoard from "./components/Pages/DashBoard";
import EditTask from "./components/Pages/EditTask";
import Home from "./components/Pages/Home"

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/DashBoard',
    element: <DashBoard />
  },
  {
    path: '/EditTask',
    element: <EditTask />
  }
];

export default AppRoutes;
