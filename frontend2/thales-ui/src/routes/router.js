import {createBrowserRouter} from "react-router-dom";
import RootLayout from "../layout/RootLayout";
import WeatherDashboardPage from "../pages/WeatherDashboardPage";
import SecondPage from "../pages/SecondPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout/>,
    children: [
      {
        path: "",
        element: <WeatherDashboardPage/>
      },
      {
        path: "secondRoute/:country",
        element: <SecondPage/>
      }
    ]
  }
]);

export default router;