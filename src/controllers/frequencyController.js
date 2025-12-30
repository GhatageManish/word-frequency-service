import { calculateWordFrequency } from "../utils/wordCounter.js";

export const countFrequency = (req, res) => {
  const { text } = req.body;

  if (!text || typeof text !== "string") {
    return res.status(400).json({
      error: "Invalid input. 'text' must be a non-empty string."
    });
  }

  const result = calculateWordFrequency(text);
  res.status(200).json(result);
};