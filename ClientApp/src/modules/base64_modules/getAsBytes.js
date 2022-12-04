import get_base64_fromFile from "./modules/get_base64_fromFile";
import get_base64_fromString from "./modules/get_base64_fromString";

async function getAsBytes(content, isFile) {
    if(isFile === true) {
        return await get_base64_fromFile(content);
    }

    if(isFile === false) {
        return await get_base64_fromString(content);
    }
}
export default getAsBytes;
