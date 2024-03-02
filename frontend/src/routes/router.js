import {createBrowserRouter} from "react-router-dom";
import RootLayout from "../layout/RootLayout";
import WeatherDashboardPage from "../pages/WeatherDashboardPage";

const router = createBrowserRouter([
  {
    path: "/",
    element: <RootLayout/>,
    children: [
      {
        path: "",
        element: <WeatherDashboardPage/>
      }
    ]
  }
])

export default router;