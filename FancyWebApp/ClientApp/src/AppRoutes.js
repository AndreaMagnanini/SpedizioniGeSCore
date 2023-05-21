import Home from "./pages/Home";
import Events from "./pages/Events";
import Locations from "./pages/Locations";
import Shipments from "./pages/Shipments";

const AppRoutes = [
  {
    index: 1,
    path: "/home",
    element: <Home/>
  },
  {
    index: 2,
    path: "/shipments",
    element: <Shipments/>
  },
  {
    index: 3,
    path: "/events",
    element: <Events/>
  },
  {
    index: 4,
    path: "/locations",
    element: <Locations/>
  }
];

export default AppRoutes;
