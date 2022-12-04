async function get_base64_fromString(content){
    const base64 = window.btoa(content);
    return base64;
}
export default get_base64_fromString;