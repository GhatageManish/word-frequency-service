import { Router } from "express";
import { countFrequency } from "../controllers/frequencyController.js";

const router = Router();

router.post("/word-frequency", countFrequency);

export default router;