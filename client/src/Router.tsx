import { createBrowserRouter } from "react-router-dom";
import HomePage from "./pages/HomePage";
import Chat from "./pages/ChatPage";

const router = createBrowserRouter([
  {
      path: '/',
      element: <HomePage />,
  },
  {
      path: '/chat',
      element: <Chat />,
  },
]);

export default router;