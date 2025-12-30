export const calculateWordFrequency = (text) => {
  const words = text
    .toLowerCase()
    .replace(/[^a-z0-9\s]/g, "")
    .split(/\s+/)
    .filter(word => word.length > 0);

  const frequencyMap = {};

  for (const word of words) {
    frequencyMap[word] = (frequencyMap[word] || 0) + 1;
  }

  return frequencyMap;
};