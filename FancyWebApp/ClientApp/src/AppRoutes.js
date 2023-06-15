import Home from "./pages/Home";
import Events from "./pages/Events";
import Locations from "./pages/Locations";
import Shipments from "./pages/Shipments";

const AppRoutes = [
  {
    index: 1,
    path: "",
    element: <Home year={2023}/>
  },
  {
    index: 2,
    path: "/shipments",
    element: <Shipments year={2023}/>
  },
  {
    index: 3,
    path: "/events",
    element: <Events year={2023}/>
  },
  {
    index: 4,
    path: "/locations",
    element: <Locations year={2023}/>
  }
];

export default AppRoutes;
