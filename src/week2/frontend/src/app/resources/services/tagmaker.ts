export function tagMaker(tagList: string): string[] {
    if(!tagList) return [];
    const tags = tagList.toLowerCase().split(" ");
    return [...new Set(tags)];
}