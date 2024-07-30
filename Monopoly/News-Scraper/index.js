const express = require('express');
const request = require('request');
const cheerio = require('cheerio');
const ExcelJS = require('exceljs');
const app = express();

app.get('/', function(req, res) {
    const url = 'https://improb.com/best-truth-or-dare-questions/';

    request(url, function(error, response, html) {
        if (error) {
            return res.status(500).send({ error: 'Failed to fetch the webpage' });
        }

        const $ = cheerio.load(html);
        const truthQuestionList = [];
        const dareQuestionList = [];

        $('#sticky-container > div.new_cus_post_container > span > div > div.centerContent > ol:nth-child(3) > li').each((i, element) => {
            const truthList = $(element).text();
            truthQuestionList.push(truthList);
        });

        $('#sticky-container > div.new_cus_post_container > span > div > div.centerContent > ol:nth-child(6) > li').each((i, element) => {
            const dareList = $(element).text();
            dareQuestionList.push(dareList);
        });

        // Create a new Excel workbook and sheet
        const workbook = new ExcelJS.Workbook();
        const worksheet = workbook.addWorksheet('Truth or Dare Questions');

        // Add columns for truth and dare questions
        worksheet.columns = [
            { header: 'Truth Questions', key: 'truth' },
            { header: 'Dare Questions', key: 'dare' }
        ];

        // Add rows to the worksheet
        const maxLength = Math.max(truthQuestionList.length, dareQuestionList.length);
        for (let i = 0; i < maxLength; i++) {
            worksheet.addRow({
                truth: truthQuestionList[i] || '',
                dare: dareQuestionList[i] || ''
            });
        }

        // Save the Excel file to the filesystem
        const filePath = 'TruthOrDareQuestions.xlsx';
        workbook.xlsx.writeFile(filePath)
            .then(() => {
                res.send({ message: 'Excel file created successfully', file: filePath });
            })
            .catch((err) => {
                res.status(500).send({ error: 'Failed to save the Excel file' });
            });
    });
});

app.listen(8080, () => {
    console.log('API is running on http://localhost:8080');
});

module.exports = app;
