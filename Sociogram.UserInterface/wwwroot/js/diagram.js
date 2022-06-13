function createDiagram(listOfStudents, listOfStudents2) {

    var myListOfStudents = JSON.parse(listOfStudents);
    var myListOfStudents2 = JSON.parse(listOfStudents2);
    var cos = myListOfStudents.$values;
    var cos2 = myListOfStudents2.$values;
    // create an array with nodes
    var nodes = new vis.DataSet([
        { id: 1, label: 'Aleksander Solich' },
        { id: 2, label: 'Michał Zatara' },
        { id: 3, label: 'Kosma Roznowski' }
    ]);

    // create an array with edges
    var edges = new vis.DataSet([
        { from: 1, to: 2 },
        { from: 1, to: 3 },
        { from: 2, to: 3 },
        { from: 2, to: 1 }
    ]);

    // create a network
    var container = document.getElementById('mynetwork');

    // provide the data in the vis format
    var data = {
        nodes: nodes,
        edges: edges
    };
    var options = {};

    // initialize your network!
    var network = new vis.Network(container, data, options);
}