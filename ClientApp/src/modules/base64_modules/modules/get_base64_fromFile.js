async function get_base64_fromFile(file){
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => resolve(reader.result.toString().substr(reader.result.toString().indexOf(',') + 1));
        reader.onerror = error => reject(error);
    });
}
export default get_base64_fromFile;