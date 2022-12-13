using System.Drawing;
using Services.Contracts;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.Diagnostics;
using System.IO;

namespace Services.Services
{
    public class AiService : IAiService
    {
        // variables
        private Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier
            (Directory.GetCurrentDirectory() 
            + @"\..\Services\Services\haarcascade_frontalface_alt.xml");

        Image<Bgr, Byte> faceResult = null;

        List<Image<Gray, Byte>> TrainedFaces = new List<Image<Gray, byte>>();
        List<int> PersonsLabes = new List<int>();
        List<string> PersonsNames = new List<string>();

        EigenFaceRecognizer recognizer;

        // upload image
        public bool UploadImage(string name, string[] listData, string localPath)
        {
            string[] listFilename = new string[listData.Length];
            for (var i = 0; i < listData.Length; i++)
            {
                var data = listData[i];
                var t = data.Substring(22); // remove data:image/png;base64,
                byte[] bytes = Convert.FromBase64String(t);
                // save image
                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }
                var fileName = name + i + ".png";
                listFilename[i] = fileName;
                // folder for training image
                Directory.CreateDirectory(localPath + "/Images/" + name);
                var fullPath = Path.Combine(localPath + "/Images/" + name, fileName);
                //var fullPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            DetectFace(name, listFilename, localPath);
            Directory.Delete(localPath + "/Images/" + name, true);
            return RecognizeFace(name);
        }

        // register image
        public bool RegisterImage(string name, string[] listData, string localPath)
        {
            string[] listFilename = new string[listData.Length];
            for (var i = 0; i < listData.Length; i++)
            {
                var data = listData[i];
                var t = data.Substring(22); // remove data:image/png;base64,
                byte[] bytes = Convert.FromBase64String(t);
                // save image
                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }
                var fileName = name + i + ".png";
                listFilename[i] = fileName;
                // folder for training image
                Directory.CreateDirectory(localPath + "/Images/" + name);
                var fullPath = Path.Combine(localPath + "/Images/" + name, fileName);
                //var fullPath = Path.Combine(Server.MapPath("~/Images/"), fileName);
                image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            DetectFace(name, listFilename, localPath);
            Directory.Delete(localPath + "/Images/" + name, true);
            return TrainImagesFromDir(name);
        }

        // detect face in image
        private void DetectFace(string name, string[] listFileName, string localPath)
        {
            for (var i = 0; i < listFileName.Length; i++)
            {
                var fileName = listFileName[i];
                string pathFileImage = Path.Combine(localPath + "/Images/" + name, fileName);
                currentFrame = new Image<Bgr, byte>(pathFileImage).Resize(700, 500, Inter.Cubic);

                //Convert from Bgr to Gray Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                //Enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);
                // detect face
                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(grayImage, 1.1, 
                                        3, Size.Empty, Size.Empty);

                Image<Bgr, Byte> resultImage = currentFrame.Convert<Bgr, Byte>();
                if (faces.Length > 0)
                {
                    var j = 0;
                    foreach (var face in faces)
                    {
                        //We will create a directory if does not exists!
                        string path = Directory.GetCurrentDirectory() + @"\TrainedImages\" + name;
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);
                        resultImage.ROI = face;
                        //resize the image then saving it
                        resultImage.Resize(100, 100, Inter.Cubic).Save(path + @"\" + name + i.ToString()
                                + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".png");
                        j++;
                    }
                } 
                else
                {
                    throw new Exception("Cannot detect face");
                }
            }
        }

        // train Images .. we will use the saved images from the previous example 
        private bool TrainImagesFromDir(string name)
        {
            int ImagesCount = 0;
            double Threshold = 20000000;
            TrainedFaces.Clear();
            PersonsLabes.Clear();
            PersonsNames.Clear();
            // load recognizer from file if has file
            string recognizerFilePath = Directory.GetCurrentDirectory() + @"\recognizer\" + name;
            Directory.CreateDirectory(recognizerFilePath);
            recognizerFilePath = recognizerFilePath + @"\recognizer.yml";
            if (File.Exists(recognizerFilePath))
            {
                recognizer = new EigenFaceRecognizer();
                recognizer.Read(recognizerFilePath);
            }
            else
            {
                recognizer = new EigenFaceRecognizer(ImagesCount, Threshold);
            }

            string path = Directory.GetCurrentDirectory() + @"\TrainedImages\" + name;
            try
            {
                // get all images files
                string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    Image<Gray, byte> trainedImage = new Image<Gray, byte>(file)
                        .Resize(100, 100, Inter.Cubic);
                    CvInvoke.EqualizeHist(trainedImage, trainedImage);
                    TrainedFaces.Add(trainedImage);
                    PersonsLabes.Add(ImagesCount);
                    PersonsNames.Add(name);
                    ImagesCount++;
                    Debug.WriteLine(">>> train " + ImagesCount + ". " + name);
                }

                if (TrainedFaces.Count() > 0)
                {
                    Image<Gray, byte>[] trainedImage = TrainedFaces.ToArray();
                    int[] personLabes = PersonsLabes.ToArray();
                    List<Mat> mats = new List<Mat>();
                    for (int i = 0; i < trainedImage.Length; i++)
                    {
                        mats.Add(trainedImage[i].Mat);
                    }
                    mats.ToArray();

                    recognizer.Train(mats.ToArray(), personLabes);
                    // write recognizer to file
                    recognizer.Write(recognizerFilePath);
                    Directory.Delete(path, true);
                    return true;
                }
                else
                {
                    Directory.Delete(path, true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in Train Images: " + ex.Message);
                Directory.Delete(path, true);
                return false;
            }

        }

        // recognize face
        private bool RecognizeFace(string name)
        {
            Debug.WriteLine("recognize");
            // get all images files
            string path = Directory.GetCurrentDirectory() + @"\TrainedImages\" + name;
            string[] files = Directory.GetFiles(path, "*.png", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                Image<Gray, Byte> grayFaceResult = new Image<Gray, byte>(file)
                    .Convert<Gray, Byte>().Resize(100, 100, Inter.Cubic);

                CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);

                EigenFaceRecognizer recognizer = new EigenFaceRecognizer();
                string recognizerFilePath = Directory.GetCurrentDirectory()
                        + @"\recognizer\" + name + @"\recognizer.yml";
                recognizer.Read(recognizerFilePath);
                var result = recognizer.Predict(grayFaceResult);

                Debug.WriteLine("recognize " + result.Label + ". " + result.Distance);
                if (result.Label != -1 && result.Distance < 2000)
                {
                    Debug.WriteLine("found face");
                    Directory.Delete(path, true);
                    return true;
                }
            }
            Directory.Delete(path, true);
            Debug.WriteLine("not found face");
            return false;
        }
    }
}
