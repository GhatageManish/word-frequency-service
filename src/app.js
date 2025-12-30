import express from "express";
import frequencyRoutes from "./routes/frequencyRoutes.js";

const app = express();

app.use(express.json());
app.use("/api", frequencyRoutes);

app.listen(3000, () => {
  console.log("Server running on port 3000");
});