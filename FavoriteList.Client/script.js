async function getAll() {
  try {
    const request = await fetch("http://localhost:5285/api/FavList/GetAll");
    const response = await request.json();
    createTbody(response);
  } catch (error) {
    console.log(error);
  }
}

function createTbody(data) {
  const tbodyEl = document.getElementById("tablo");
  tbodyEl.innerHTML = "";
  data.forEach((content, index) => {
    const row = `<tr>
            <td>
                ${+index + 1}
            </td>
            <td>
            ${content.contentType}
            </td>
            <td>
            ${content.name}
            </td>
            <td>
            ${content.star}
            </td>
            <td>
            <button class="btn btn-primary" onclick="updatePage('${
              content.id
            }','${content.contentType}','${content.name}','${
      content.star
    }')" data-bs-toggle="modal" data-bs-target="#updateModel">Düzenle</button>
            <button class="btn btn-danger" onclick="deleteById('${
              content.id
            }')">Sil</button>
            </td>
        </tr>`;
    tbodyEl.innerHTML += row;
  });
}

function createEntity() {
  const contentTypeEl = document.getElementById("contentType");
  const nameEl = document.getElementById("name");
  const starEl = document.getElementById("score");
  const closeBtn = document.getElementById("addModalCloseBtn");
  const endpoint = `http://localhost:5285/api/FavList/Create?contentType=${contentTypeEl.value}&name=${nameEl.value}&star=${starEl.value}`;
  fetch(endpoint, { method: "POST" }).then(() => {
    contentTypeEl.value = "";
    nameEl.value = "";
    starEl.value = "";
    closeBtn.click();
    getAll();
  });
}

function deleteById(id) {
  const result = confirm("Silmek istiyor musun?");
  const endpoint = `http://localhost:5285/api/FavList/DeleteById?id=${id}`;
  if (result == true) {
    fetch(endpoint, { method: "DELETE" }).then(() => {
      getAll();
    });
  }
}

let editId = "";
const updateContentTypeEl = document.getElementById("updateContentType");
const updateNameEl = document.getElementById("updateName");
const updateStarEl = document.getElementById("updateScore");

function updatePage(id, contentType, name, star) {
  updateContentTypeEl.value = contentType;
  updateNameEl.value = name;
  updateStarEl.value = star;
  editId = id;
}

function updateEntity() {
  const closeBtn = document.getElementById("updateModalCloseBtn");

  const endpoint = `http://localhost:5285/api/FavList/UpdateById?id=${editId}&contentType=${updateContentTypeEl.value}&name=${updateNameEl.value}&star=${updateStarEl.value}`;
  fetch(endpoint, { method: "PUT" }).then(() => {
    getAll();
    closeBtn.click();
    editId = "";
  });
}

window.onload = getAll();
